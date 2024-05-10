using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.Enums;
using PersonalWebSiteMVC.Entity.ViewModels.Portfolios;
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

        public async Task<Portfolio> GetPortfolioByIdAsync(int portfolioId)
        {
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetAsync(x=>x.Id == portfolioId, i => i.Image);
            return portfolio;
        } 

        public async Task<List<PorfolioViewModel>> GetAllPortfolioWithImageAsync()
        {
            var portfolios = await unitOfWork.GetRepository<Portfolio>().GetAllAsync(x => !x.IsDeleted, i=>i.Image);

            var portfolioViewModelMap = mapper.Map<List<PorfolioViewModel>>(portfolios);

            return portfolioViewModelMap.ToList();
        }

        public async Task<string> CreatePortfolioAsync(PortfolioAddViewModel portfolioAddViewModel)
        {
            var imageUpload = await imageHelper.Upload($"porfolio_{DateTime.Now}", portfolioAddViewModel.Photo, ImageType.Post);

            Image image = new(imageUpload.FullName, portfolioAddViewModel.Photo.ContentType);

            await unitOfWork.GetRepository<Image>().AddAsync(image);
            await unitOfWork.SaveAsync();

            var map = mapper.Map<Portfolio>(portfolioAddViewModel);
            map.ImageId = image.Id;

            await unitOfWork.GetRepository<Portfolio>().AddAsync(map);
            await unitOfWork.SaveAsync();

            return map.Title;
        }

        private async Task<int> UploadImageForPost(PortfolioUpdateViewModel portfolioUpdateViewModel)
        {
            var imageUpload = await imageHelper.Upload($"{portfolioUpdateViewModel.Title}", portfolioUpdateViewModel.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, portfolioUpdateViewModel.Photo.ContentType);
            await unitOfWork.GetRepository<Image>().AddAsync(image);
            await unitOfWork.SaveAsync();
            return image.Id;
        }

        public async Task<bool> UpdatePortfolioAsync(PortfolioUpdateViewModel portfolioUpdateViewModel)
        {
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetByIdAsync(portfolioUpdateViewModel.Id);

            var imageId = portfolio.ImageId;

            mapper.Map(portfolioUpdateViewModel, portfolio);

            if (portfolioUpdateViewModel.Photo != null)
                portfolio.ImageId = await UploadImageForPost(portfolioUpdateViewModel);
            else
                portfolio.ImageId = imageId;

            await unitOfWork.GetRepository<Portfolio>().UpdateAsync(portfolio);
            await unitOfWork.SaveAsync();

            return true;
        }

        public async Task<string> SafeDeletePortfolioAsync(int portfolioId)
        {
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetByIdAsync(portfolioId);

            portfolio.IsDeleted = true;
            portfolio.DeletedDate = DateTime.Now;
            portfolio.DeletedBy = "undefined";

            await unitOfWork.GetRepository<Portfolio>().UpdateAsync(portfolio);
            await unitOfWork.SaveAsync();

            return portfolio.Title;
        }

    }
}
