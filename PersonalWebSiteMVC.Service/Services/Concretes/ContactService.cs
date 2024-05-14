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

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            var contacts = await unitOfWork.GetRepository<Contact>().GetAllAsync(x => !x.IsDeleted);
            return contacts;
        }

        public async Task<string> CreateContactAsync(ContactViewModel contactViewModel)
        {
            var map = mapper.Map<Contact>(contactViewModel);
            map.CreatedDate = DateTime.Now;
            await unitOfWork.GetRepository<Contact>().AddAsync(map);
            await unitOfWork.SaveAsync();
            return contactViewModel.Subject;
        }

        public async Task<string> SafeDeleteContactAsync(int contactId)
        {
            var contact = await unitOfWork.GetRepository<Contact>().GetByIdAsync(contactId);

            contact.IsDeleted = true;
            contact.DeletedDate = DateTime.Now;
            contact.DeletedBy = "undefined";

            await unitOfWork.GetRepository<Contact>().UpdateAsync(contact);
            await unitOfWork.SaveAsync();

            return contact.Subject;
        }

    }
}
