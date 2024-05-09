using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
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

            return experiencesListViewModelMap;

        }

        public async Task<string> CreateExperienceAsync(ExperienceAddViewModel experienceAddViewModel)
        {
            var experienceMap = mapper.Map<Experience>(experienceAddViewModel);

            await unitOfWork.GetRepository<Experience>().AddAsync(experienceMap);
            await unitOfWork.SaveAsync();

            return experienceMap.Title;
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
