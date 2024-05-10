using AutoMapper;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.SocialMedias;

namespace PersonalWebSiteMVC.Service.AutoMapper.SocialMedias
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, SocialMediaAddViewModel>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaViewModel>().ReverseMap();
        }
    }
}
