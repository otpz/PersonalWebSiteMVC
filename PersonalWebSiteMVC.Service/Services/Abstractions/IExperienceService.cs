using PersonalWebSiteMVC.Entity.ViewModels.Experiences;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IExperienceService
    {
        Task<List<ExperienceListViewModel>> GetAllExperiencesAsync();
        Task<ExperienceUpdateViewModel> GetExperienceById(int experienceId);
        Task<string> CreateExperienceAsync(ExperienceAddViewModel experienceAddViewModel);
        Task<string> UpdateExperienceAsync(ExperienceUpdateViewModel experienceUpdateViewModel);
        Task<string> SafeDeleteExperienceAsync(int experienceId);
    }
}
