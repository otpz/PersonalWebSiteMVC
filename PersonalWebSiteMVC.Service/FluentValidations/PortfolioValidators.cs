using FluentValidation;
using PersonalWebSiteMVC.Entity.ViewModels.Portfolios;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class PortfolioValidators : AbstractValidator<PortfolioAddViewModel>
    {
        public PortfolioValidators()
        {
            //RuleFor(x => x.Photo)
            //    .NotEmpty()
            //    .NotNull()
            //    .WithName("Resim");

            RuleFor(x => x.Title)
                 .NotEmpty()
                 .MinimumLength(1)
                 .NotNull()
                 .MaximumLength(50)
                 .WithName("Deneyim Başlığı");

            RuleFor(x => x.Description)
               .NotEmpty()
               .MinimumLength(10)
               .MaximumLength(600)
               .NotNull()
               .WithName("Deneyim Açıklaması");
        }
    }
}
