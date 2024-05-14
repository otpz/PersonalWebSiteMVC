using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Contacts;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactsAsync();
        Task<string> CreateContactAsync(ContactViewModel contactViewModel);
        Task<string> SafeDeleteContactAsync(int contactId);
    }
}
