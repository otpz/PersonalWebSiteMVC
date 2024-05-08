using PersonalWebSiteMVC.Entity.ViewModels.Talents;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface ITalentService
    {
        Task<List<TalentViewModel>> GetAllTalentsWithImageAsync();
        Task<string> CreateTalentAsync(TalentAddViewModel talentAddViewModel);
        Task<string> SafeDeleteTalentAsync(int talentId);
    }
}
