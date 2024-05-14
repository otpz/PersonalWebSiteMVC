using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IToastNotification toastNotification;

        public ContactController(IContactService contactService, IToastNotification toastNotification)
        {
            this.contactService = contactService;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await contactService.GetAllContactsAsync();
            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int contactId)
        {
            string contactSubject = await contactService.SafeDeleteContactAsync(contactId);
            toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Contact.Delete(contactSubject), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Contact", new { Area = "Admin" });
        }
    }
}
