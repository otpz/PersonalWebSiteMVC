using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Entity.ViewModels.Contacts;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class FormContactViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ContactViewModel(); // Varsayılan model oluştur
            return View(model); // Modeli view'a gönder
        }
    }
}
