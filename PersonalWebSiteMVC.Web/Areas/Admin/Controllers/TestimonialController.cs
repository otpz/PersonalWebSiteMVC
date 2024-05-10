using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService testimonialService;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<Testimonial> validator;

        public TestimonialController(ITestimonialService testimonialService, IToastNotification toastNotification, IValidator<Testimonial> validator)
        {
            this.testimonialService = testimonialService;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var testimonials = await testimonialService.GetAllTestimonialsAsync();
            return View(testimonials);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Testimonial testimonial)
        {
            var validationResult = await validator.ValidateAsync(testimonial);
            
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi", new ToastrOptions { Title = "Hata" });
                return View();
            }

            var testimonialName = await testimonialService.CreateTestimonialAsync(testimonial);
            toastNotification.AddSuccessToastMessage(Messages.Testimonial.Add(testimonialName), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Testimonials", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int testimonialId)
        {
            var testimonialName = await testimonialService.SafeDeleteTestimonialAsync(testimonialId);
            toastNotification.AddSuccessToastMessage(Messages.Testimonial.Delete(testimonialName), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Testimonials", new { Area = "Admin" });
        }

    }
}
