using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.Enums;
using PersonalWebSiteMVC.Entity.ViewModels.SocialMedias;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;
using PersonalWebSiteMVC.Service.Helpers.Images;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageHelper imageHelper;

        public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.imageHelper = imageHelper;
        }

        public async Task<List<SocialMediaViewModel>> GetAllSocialMediasWithImageAsync()
        {
            var socials = await unitOfWork.GetRepository<SocialMedia>().GetAllAsync(x=>!x.IsDeleted, i=>i.Image);
            var socialMediasMap = mapper.Map<List<SocialMediaViewModel>>(socials);
            return socialMediasMap.ToList();
        }

        public async Task<string> CreateSocialMediaAsync(SocialMediaAddViewModel socialMediaAddViewModel)
        {
            var imageUpload = await imageHelper.Upload(socialMediaAddViewModel.Title, socialMediaAddViewModel.Photo, ImageType.Post);

            var image = new Image
            {
                FileName = imageUpload.FullName,
                FileType = socialMediaAddViewModel.Photo.ContentType,
            };

            await unitOfWork.GetRepository<Image>().AddAsync(image);
            await unitOfWork.SaveAsync();

            var socialMedia = new SocialMedia
            {
                Title = socialMediaAddViewModel.Title,
                Url = socialMediaAddViewModel.Url,
                ImageId = image.Id,
            };

            await unitOfWork.GetRepository<SocialMedia>().AddAsync(socialMedia);
            await unitOfWork.SaveAsync();

            return socialMedia.Title;
        }

        public async Task<string> SafeDeleteSocialMediaAsync(int socialMediaInt)
        {
            var socialMedia = await unitOfWork.GetRepository<SocialMedia>().GetByIdAsync(socialMediaInt);

            socialMedia.IsDeleted = true;
            socialMedia.DeletedDate = DateTime.Now;
            socialMedia.DeletedBy = "undefined";

            await unitOfWork.GetRepository<SocialMedia>().UpdateAsync(socialMedia);
            await unitOfWork.SaveAsync();

            return socialMedia.Title;
        }

    }
}
