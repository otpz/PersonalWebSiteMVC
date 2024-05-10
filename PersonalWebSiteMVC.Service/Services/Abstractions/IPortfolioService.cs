using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Portfolios;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IPortfolioService
    {
        Task<List<PorfolioViewModel>> GetAllPortfolioWithImageAsync();
        Task<string> CreatePortfolioAsync(PortfolioAddViewModel portfolioAddViewModel);
        Task<bool> UpdatePortfolioAsync(PortfolioUpdateViewModel portfolioUpdateViewModel);
        Task<string> SafeDeletePortfolioAsync(int talentId);
        Task<Portfolio> GetPortfolioByIdAsync(int portfolioId);
    }
}
