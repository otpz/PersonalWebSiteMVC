using PersonalWebSiteMVC.Entity.ViewModels.Experiences;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IExperienceService
    {
        Task<List<ExperienceListViewModel>> GetAllExperiencesAsync();
        Task<string> CreateExperienceAsync(ExperienceAddViewModel experienceAddViewModel);
        Task<string> SafeDeleteExperienceAsync(int experienceId);
    }
}
