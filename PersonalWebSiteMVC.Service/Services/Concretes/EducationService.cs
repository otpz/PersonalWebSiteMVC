using AutoMapper;
using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Educations;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class EducationService : IEducationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EducationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<EducationListViewModel>> GetAllEducationsAsync()
        {
            var educations = await unitOfWork.GetRepository<Education>().GetAllAsync(x => !x.IsDeleted);
            var educationsListViewModelMap = mapper.Map<List<EducationListViewModel>>(educations);
            return educationsListViewModelMap;
        }

        public async Task<string> CreateEducationAsync(EducationAddViewModel educationAddViewModel)
        {
            var map = mapper.Map<Education>(educationAddViewModel);

            await unitOfWork.GetRepository<Education>().AddAsync(map);
            await unitOfWork.SaveAsync();

            return map.Title;
        }

        public async Task<string> SafeDeleteEducationAsync(int educationId)
        {
            var education = await unitOfWork.GetRepository<Education>().GetByIdAsync(educationId);

            education.IsDeleted = true;
            education.DeletedDate = DateTime.Now;
            education.DeletedBy = "undefined";

            await unitOfWork.GetRepository<Education>().UpdateAsync(education);
            await unitOfWork.SaveAsync();

            return education.Title;
        }

    }
}
