using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.Enums;
using PersonalWebSiteMVC.Entity.ViewModels.Users;
using PersonalWebSiteMVC.Service.Extensions;
using PersonalWebSiteMVC.Service.Helpers.Images;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using System.Security.Claims;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal user;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.imageHelper = imageHelper;
            user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<UserViewModel>> GetAllUserAsync()
        {
            var users = await unitOfWork.GetRepository<AppUser>().GetAllAsync();
            var map = mapper.Map<List<UserViewModel>>(users);
            return map;
        }

        public async Task<UserViewModel> GetFirstUserAsync(int id)
        {
            var users = await unitOfWork.GetRepository<AppUser>().GetByIdAsync(id);
            var map = mapper.Map<UserViewModel>(users);
            return map;
        }

        public async Task<UserViewModel> GetUserProfile()
        {
            var userId = user.GetLoggedInUserId();

            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserViewModel>(getUserWithImage);
     
            if (getUserWithImage.Image != null)
                map.Image.FileName = getUserWithImage.Image.FileName;

            return map;
        }

        private async Task<int> UploadImageForUser(UserViewModel userViewModel)
        {
            var imageUpload = await imageHelper.Upload($"{userViewModel.FirstName} {userViewModel.LastName}", userViewModel.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userViewModel.Photo.ContentType);
            await unitOfWork.GetRepository<Image>().AddAsync(image);
            await unitOfWork.SaveAsync();
            return image.Id;
        }

        public async Task<AppUser> GetAppUserByIdAsync(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            return user;
        }

        public async Task<bool> UpdateUserProfileAsync(UserViewModel userViewModel)
        {
            var userId = user.GetLoggedInUserId();

            var appUser = await GetAppUserByIdAsync(userId);

            var imageId = appUser.ImageId;

            await userManager.UpdateSecurityStampAsync(appUser);

            mapper.Map(userViewModel, appUser);

            if (userViewModel.Photo != null)
                appUser.ImageId = await UploadImageForUser(userViewModel);
            else
                appUser.ImageId = imageId;

            await userManager.UpdateAsync(appUser);
            await unitOfWork.SaveAsync();
            return true;
        }

    }
}
