using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.ViewModels.Portfolios;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService portfolioService;
        private readonly IValidator<PortfolioAddViewModel> validator;
        private readonly IToastNotification toastNotification;
        private readonly IMapper mapper;

        public PortfolioController(IPortfolioService portfolioService, IValidator<PortfolioAddViewModel> validator, IToastNotification toastNotification, IMapper mapper)
        {
            this.portfolioService = portfolioService;
            this.validator = validator;
            this.toastNotification = toastNotification;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var portfolios = await portfolioService.GetAllPortfolioWithImageAsync();
            return View(portfolios);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PortfolioAddViewModel portfolioAddViewModel)
        {
            var validationResult = await validator.ValidateAsync(portfolioAddViewModel);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi.", new ToastrOptions { Title = "Hata" });
                return View();
            }

            string portfolioTitle = await portfolioService.CreatePortfolioAsync(portfolioAddViewModel);
            toastNotification.AddSuccessToastMessage(Messages.Portfolio.Add(portfolioTitle), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Portfolio", new {Area = "Admin"});
        }

        [HttpGet]
        public async Task<IActionResult> Update(int portfolioId)
        {
            var portfolio = await portfolioService.GetPortfolioByIdAsync(portfolioId);
            var portfolioViewModelMap = mapper.Map<PortfolioUpdateViewModel>(portfolio);
            return View(portfolioViewModelMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PortfolioUpdateViewModel portfolioUpdateViewModel)
        {
            var map = mapper.Map<PortfolioAddViewModel>(portfolioUpdateViewModel);
            var validationResult = await validator.ValidateAsync(map);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi.", new ToastrOptions { Title = "Hata" });
                return View(portfolioUpdateViewModel);
            }

            await portfolioService.UpdatePortfolioAsync(portfolioUpdateViewModel);

            toastNotification.AddSuccessToastMessage(Messages.Portfolio.Update("Güncelleme başarılı"), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Portfolio", new { Area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int portfolioId)
        {
            string portfolioTitle = await portfolioService.SafeDeletePortfolioAsync(portfolioId);
            toastNotification.AddSuccessToastMessage(Messages.Portfolio.Delete(portfolioTitle), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Portfolio", new { Area = "Admin" });
        }
    }
}
