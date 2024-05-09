using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface ISummaryService
    {
        Task<Summary> GetFirstSummaryAsync();
        Task<string> UpdateSummaryAsync(Summary summary);
    }
}
