using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<User>> GetAllUserAsync();
    }
}
