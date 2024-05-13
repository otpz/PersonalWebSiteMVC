using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await contactService.GetAllContactsAsync();
            return View(contacts);
        }
    }
}
