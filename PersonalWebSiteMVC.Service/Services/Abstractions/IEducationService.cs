using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Educations;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IEducationService
    {
        Task<List<EducationListViewModel>> GetAllEducationsAsync();
        Task<string> CreateEducationAsync(EducationAddViewModel educationAddViewModel);
        Task<string> SafeDeleteEducationAsync(int educationId);
    }
}
