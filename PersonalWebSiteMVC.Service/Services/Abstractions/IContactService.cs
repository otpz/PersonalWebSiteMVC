using PersonalWebSiteMVC.Entity.ViewModels.Contacts;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IContactService
    {
        Task<List<ContactViewModel>> GetAllContactsAsync();
    }
}
