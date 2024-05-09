using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.ViewModels.Users;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Service.Services.Concretes;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<UserViewModel> validator;

        public UserController(IUserService userService, IToastNotification toastNotification, IValidator<UserViewModel> validator)
        {
            this.userService = userService;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var user = await userService.GetUserProfile();

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel userViewModel)
        {
            var results = await validator.ValidateAsync(userViewModel);
            if (!results.IsValid)
            {
                results.AddToModelState(this.ModelState);
                return View(userViewModel);
            }

            if (ModelState.IsValid)
            {
                var result = await userService.UpdateUserProfileAsync(userViewModel);
                if (result)
                {
                    toastNotification.AddSuccessToastMessage("Profil güncelleme işlemi başarıyla tamamlandı.", new ToastrOptions { Title = "Başarılı" });
                }
                else
                {
                    var profile = await userService.GetUserProfile();
                    toastNotification.AddErrorToastMessage("Profil güncellenirken bir hata oluştu.", new ToastrOptions { Title = "Hata!" });
                    return View(profile);
                }
                return RedirectToAction("Update", "User", new { Area = "Admin" });
            }
            else
                return NotFound();
        }
        
    }
}
