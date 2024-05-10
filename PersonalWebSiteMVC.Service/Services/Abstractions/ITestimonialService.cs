using PersonalWebSiteMVC.Entity.Entities;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Service.Services.Abstractions
{
    public interface ITestimonialService
    {
        Task<List<Testimonial>> GetAllTestimonialsAsync();
        Task<string> CreateTestimonialAsync(Testimonial testimonial);
        Task<string> SafeDeleteTestimonialAsync(int testimonialId);
    }
}
