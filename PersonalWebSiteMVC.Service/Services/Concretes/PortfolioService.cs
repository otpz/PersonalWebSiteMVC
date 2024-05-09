using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.Enums;
using PersonalWebSiteMVC.Entity.ViewModels.Portfolios;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;
using PersonalWebSiteMVC.Service.Helpers.Images;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageHelper imageHelper;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.imageHelper = imageHelper;
        }

        public async Task<List<PorfolioViewModel>> GetAllPortfolioWithImageAsync()
        {
            var portfolios = await unitOfWork.GetRepository<Portfolio>().GetAllAsync(x => !x.IsDeleted, i=>i.Image);

            var portfolioViewModelMap = mapper.Map<List<PorfolioViewModel>>(portfolios);

            return portfolioViewModelMap.ToList();
        }
        public async Task CreatePortfolioAsync(PortfolioAddViewModel portfolioAddViewModel)
        {
            var imageUpload = await imageHelper.Upload($"porfolio_{DateTime.Now}", portfolioAddViewModel.Photo, ImageType.Post);

            Image image = new(imageUpload.FullName, portfolioAddViewModel.Photo.ContentType);

            await unitOfWork.GetRepository<Image>().AddAsync(image);
            await unitOfWork.SaveAsync();

            var map = mapper.Map<Portfolio>(portfolioAddViewModel);
            map.ImageId = image.Id;

            await unitOfWork.GetRepository<Portfolio>().AddAsync(map);
            await unitOfWork.SaveAsync();

            return map;

        }

    }
}
