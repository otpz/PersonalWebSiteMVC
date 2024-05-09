using AutoMapper;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Experiences;

namespace PersonalWebSiteMVC.Service.AutoMapper
{
    public class Experiences: Profile
    {
        public Experiences()
        {
            CreateMap<Experience, ExperienceListViewModel>().ReverseMap();
            CreateMap<Experience, ExperienceAddViewModel>().ReverseMap();
        }
    }
}
