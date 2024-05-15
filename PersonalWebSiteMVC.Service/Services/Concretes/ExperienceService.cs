using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Educations;
using PersonalWebSiteMVC.Entity.ViewModels.Experiences;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class ExperienceService : IExperienceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<ExperienceListViewModel>> GetAllExperiencesAsync()
        {
            var experiences = await unitOfWork.GetRepository<Experience>().GetAllAsync(x=>!x.IsDeleted);

            var experiencesListViewModelMap = mapper.Map<List<ExperienceListViewModel>>(experiences);

            return experiencesListViewModelMap.OrderByDescending(x => x.CreatedDate).ToList();

        }

        public async Task<ExperienceUpdateViewModel> GetExperienceById(int experienceId)
        {
            var expereince = await unitOfWork.GetRepository<Experience>().GetByIdAsync(experienceId);
            var map = mapper.Map<ExperienceUpdateViewModel>(expereince);
            return map;
        }

        public async Task<string> CreateExperienceAsync(ExperienceAddViewModel experienceAddViewModel)
        {
            var experienceMap = mapper.Map<Experience>(experienceAddViewModel);

            await unitOfWork.GetRepository<Experience>().AddAsync(experienceMap);
            await unitOfWork.SaveAsync();

            return experienceMap.Title;
        }

        public async Task<string> UpdateExperienceAsync(ExperienceUpdateViewModel experienceUpdateViewModel)
        {
            var experience = await unitOfWork.GetRepository<Experience>().GetByIdAsync(experienceUpdateViewModel.Id);

            var experienceUpdateMap = mapper.Map(experienceUpdateViewModel, experience);

            await unitOfWork.GetRepository<Experience>().UpdateAsync(experienceUpdateMap);
            await unitOfWork.SaveAsync();

            return experienceUpdateMap.Title;
        }

        public async Task<string> SafeDeleteExperienceAsync(int experienceId)
        {
            var experience = await unitOfWork.GetRepository<Experience>().GetByIdAsync(experienceId);

            experience.IsDeleted = true;
            experience.DeletedDate = DateTime.Now;
            experience.DeletedBy = "undefined";

            await unitOfWork.GetRepository<Experience>().UpdateAsync(experience);
            await unitOfWork.SaveAsync();

            return experience.Title;
        }
    }
}
