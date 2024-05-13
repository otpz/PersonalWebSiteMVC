using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ITestimonialService testimonialService;

        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await testimonialService.GetAllTestimonialsAsync();
            return View(testimonials);
        }
    }
}
