using PersonalWebSiteMVC.Entity.ViewModels.SocialMedias;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaViewModel>> GetAllSocialMediasWithImageAsync();
        Task<string> CreateSocialMediaAsync(SocialMediaAddViewModel socialMediaAddViewModel);
        Task<string> SafeDeleteSocialMediaAsync(int socialMediaInt);
    }
}
