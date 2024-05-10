using PersonalWebSiteMVC.Data.UnitOfWorks;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Service.Services.Concretes
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IUnitOfWork unitOfWork;
        public TestimonialService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Testimonial>> GetAllTestimonialsAsync()
        {
            var testimonials = await unitOfWork.GetRepository<Testimonial>().GetAllAsync();

            return testimonials;
        }
        public async Task<string> CreateTestimonialAsync(Testimonial testimonial)
        {
            await unitOfWork.GetRepository<Testimonial>().AddAsync(testimonial);
            await unitOfWork.SaveAsync();
            return $"{testimonial.FirstName} {testimonial.LastName}";
        }
        public async Task<string> SafeDeleteTestimonialAsync(int testimonialId)
        {
            var testimonial = await unitOfWork.GetRepository<Testimonial>().GetByIdAsync(testimonialId);
            
            testimonial.IsDeleted = true;
            testimonial.DeletedDate = DateTime.Now;
            testimonial.DeletedBy = "undefined";

            await unitOfWork.GetRepository<Testimonial>().UpdateAsync(testimonial);
            await unitOfWork.SaveAsync();

            return $"{testimonial.FirstName} {testimonial.LastName}";
        }
    }
}
