using FluentValidation;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class TalentValidators : AbstractValidator<TalentAddViewModel>
    {
        public TalentValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(1)
                .NotNull()
                .MaximumLength(50)
                .WithName("Yetenek Adı");

            RuleFor(x => x.Progress)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100)
                .NotNull()
                .WithName("Seviye");

            RuleFor(x => x.Photo)
                .NotEmpty()
                .NotNull()
                .WithName("Resim");
                
        }
    }
}
