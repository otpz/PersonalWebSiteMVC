using PersonalWebSiteMVC.Entity.ViewModels.Users;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUserAsync();
        Task<UserViewModel> GetFirstUserAsync(int id);
        Task<UserViewModel> GetUserProfile();
        Task<bool> UpdateUserProfileAsync(UserViewModel userViewModel);
    }
}
