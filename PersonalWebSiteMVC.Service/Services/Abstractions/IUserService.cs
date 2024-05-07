using PersonalWebSiteMVC.Entity.ViewModels.Users;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUserAsync();
    }
}
