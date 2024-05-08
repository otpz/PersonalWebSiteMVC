using PersonalWebSiteMVC.Entity.ViewModels.Talents;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface ITalentService
    {
        Task<List<TalentViewModel>> GetAllTalentsWithImageAsync();
        Task CreateTalentAsync(TalentAddViewModel talentAddViewModel);
        Task<string> SafeDeleteTalentAsync(int talentId);
    }
}
