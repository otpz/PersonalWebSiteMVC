using AutoMapper;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Contacts;

namespace PersonalWebSiteMVC.Service.AutoMapper.Contacts
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
        }
    }
}
