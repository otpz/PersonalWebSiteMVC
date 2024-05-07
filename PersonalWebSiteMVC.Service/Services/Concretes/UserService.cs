using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Users;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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

    }
}
