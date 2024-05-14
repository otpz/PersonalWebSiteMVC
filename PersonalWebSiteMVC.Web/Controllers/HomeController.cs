using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.ViewModels.Contacts;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.Models;
using System.Diagnostics;

namespace PersonalWebSiteMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;
        private readonly IContactService contactService;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<ContactViewModel> validator;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IContactService contactService, IToastNotification toastNotification, IValidator<ContactViewModel> validator)
        {
            _logger = logger;
            this.userService = userService;
            this.contactService = contactService;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetFrontProfile();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactViewModel contactViewModel)
        {
            var validationResult = await validator.ValidateAsync(contactViewModel);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi", new ToastrOptions { Title = "Hata" });
                return RedirectToAction("Index", "Home");
            }
            string contactSubject = await contactService.CreateContactAsync(contactViewModel);
            toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Contact.Add(contactSubject), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
