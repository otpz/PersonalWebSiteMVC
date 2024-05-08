using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.Enums;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;
using PersonalWebSiteMVC.Service.Helpers.Images;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class TalentService : ITalentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageHelper imageHelper;

        public TalentService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.imageHelper = imageHelper;
        }

        public async Task<List<TalentViewModel>> GetAllTalentsWithImageAsync()
        {
            var talents = await unitOfWork.GetRepository<Talent>().GetAllAsync(x => !x.IsDeleted, i => i.Image);
            var talentMap = mapper.Map<List<TalentViewModel>>(talents);
            return talentMap;
        }

        public async Task<string> CreateTalentAsync(TalentAddViewModel talentAddViewModel)
        {
            var imageUpload = await imageHelper.Upload(talentAddViewModel.Name, talentAddViewModel.Photo, ImageType.Post);
            
            var image = new Image
            {
                FileName = imageUpload.FullName,
                FileType = talentAddViewModel.Photo.ContentType,
            };

            await unitOfWork.GetRepository<Image>().AddAsync(image);
            await unitOfWork.SaveAsync();

            var talent = new Talent
            {
                Name = talentAddViewModel.Name,
                Progress = talentAddViewModel.Progress,
                ImageId = image.Id
            };

            await unitOfWork.GetRepository<Talent>().AddAsync(talent);
            await unitOfWork.SaveAsync();
                
            return talent.Name;
        }

        public async Task<string> SafeDeleteTalentAsync(int talentId)
        {
            var talent = await unitOfWork.GetRepository<Talent>().GetByIdAsync(talentId);

            talent.IsDeleted = true;
            talent.DeletedDate = DateTime.Now;
            talent.DeletedBy = null;

            await unitOfWork.GetRepository<Talent>().UpdateAsync(talent);
            await unitOfWork.SaveAsync();

            return talent.Name;
        }

    }
}
