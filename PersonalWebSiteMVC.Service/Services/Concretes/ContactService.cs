using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Contacts;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<ContactViewModel>> GetAllContactsAsync()
        {
            var contacts = await unitOfWork.GetRepository<Contact>().GetAllAsync();
            var contactsMap = mapper.Map<List<ContactViewModel>>(contacts);
            return contactsMap;
        }
    }
}
