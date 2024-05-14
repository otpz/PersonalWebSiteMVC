using AutoMapper;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Service.AutoMapper.Educations
{
    public class EducationProfile: Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, EducationListViewModel>().ReverseMap();
            CreateMap<Education, EducationAddViewModel>().ReverseMap();
            CreateMap<Education, EducationUpdateViewModel>().ReverseMap();
        }
    }
}
