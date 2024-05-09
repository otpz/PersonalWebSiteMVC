using AutoMapper;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Users;

namespace PersonalWebSiteMVC.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserViewModel>().ReverseMap();
            CreateMap<UserViewModel, AppUser>().ReverseMap();
            CreateMap<AppUser, UserLoginViewModel>().ReverseMap();
            CreateMap<AppUser, UserRegisterViewModel>().ReverseMap();
        }
    }
}
