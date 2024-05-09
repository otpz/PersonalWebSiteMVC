using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class SummaryService : ISummaryService
    {
        private readonly IUnitOfWork unitOfWork;

        public SummaryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Summary> GetFirstSummaryAsync()
        {
            var summary = await unitOfWork.GetRepository<Summary>().GetByIdAsync(1);

            return summary;
        }

        public async Task<string> UpdateSummaryAsync(Summary summary)
        {
            var currentSummary = await unitOfWork.GetRepository<Summary>().GetByIdAsync(summary.Id);
            var user = await unitOfWork.GetRepository<AppUser>().GetByIdAsync(1);

            currentSummary.PhoneNumber = user.PhoneNumber;
            currentSummary.Address = user.Address;
            currentSummary.Title = user.Title;
            currentSummary.Email = user.Email;
            currentSummary.Description = summary.Description;

            await unitOfWork.GetRepository<Summary>().UpdateAsync(currentSummary);
            await unitOfWork.SaveAsync();
            return summary.Title;
        }

    }
}
