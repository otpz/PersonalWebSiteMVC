using AutoMapper;
using Microsoft.AspNetCore.Http;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Users;
using PersonalWebSiteMVC.Service.Extensions;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using System.Security.Claims;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal user;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
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
    }
}
