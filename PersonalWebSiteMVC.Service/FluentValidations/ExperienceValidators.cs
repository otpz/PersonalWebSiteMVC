using FluentValidation;
using PersonalWebSiteMVC.Entity.ViewModels.Experiences;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class ExperienceValidators: AbstractValidator<ExperienceAddViewModel>
    {
        public ExperienceValidators()
        {
            RuleFor(x => x.Title)
                 .NotEmpty()
                 .MinimumLength(1)
                 .NotNull()
                 .MaximumLength(50)
                 .WithName("Deneyim Başlığı");

            RuleFor(x => x.Year)
                .NotEmpty()
                .MinimumLength(4)
                .NotNull()
                .WithName("Deneyim Yılları");

            RuleFor(x => x.Address)
                .NotEmpty()
                .MinimumLength(4)
                .NotNull()
                .WithName("Deneyim Yeri");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(600)
                .NotNull()
                .WithName("Deneyim Açıklaması");
        }
    }
}
