using AutoMapper;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;

namespace PersonalWebSiteMVC.Service.AutoMapper.Talents
{
    public class TalentProfile: Profile
    {
        public TalentProfile()
        {
            CreateMap<Talent, TalentViewModel>().ReverseMap();
            CreateMap<Talent, TalentAddViewModel>().ReverseMap();
        }
    }
}
