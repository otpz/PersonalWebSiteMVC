using FluentValidation;
using PersonalWebSiteMVC.Entity.ViewModels.SocialMedias;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class SocialMediaValidators : AbstractValidator<SocialMediaAddViewModel>
    {
        public SocialMediaValidators()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(1)
                .NotNull()
                .MaximumLength(20)
                .WithName("Sosyal Medya Adı");

            RuleFor(x => x.Url)
                .NotEmpty()
                .NotNull()
                .WithName("URL Adresi");

            RuleFor(x => x.Photo)
                .NotEmpty()
                .NotNull()
                .WithName("Resim");
        }
    }
}
