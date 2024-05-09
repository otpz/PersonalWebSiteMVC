using PersonalWebSiteMVC.Entity.ViewModels.Portfolios;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface IPortfolioService
    {
        Task<List<PorfolioViewModel>> GetAllPortfolioWithImageAsync()
    }
}
