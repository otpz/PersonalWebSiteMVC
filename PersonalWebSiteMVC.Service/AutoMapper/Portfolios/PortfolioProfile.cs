using AutoMapper;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Portfolios;

namespace PersonalWebSiteMVC.Service.AutoMapper.Portfolios
{
    public class PortfolioProfile: Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PorfolioViewModel>().ReverseMap();
            CreateMap<Portfolio, PortfolioAddViewModel>().ReverseMap();
            CreateMap<Portfolio, PortfolioUpdateViewModel>().ReverseMap();
            CreateMap<PortfolioUpdateViewModel, PortfolioAddViewModel>().ReverseMap();
        }
    }
}
