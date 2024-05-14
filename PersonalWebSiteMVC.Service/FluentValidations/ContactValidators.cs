using FluentValidation;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Contacts;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class ContactValidators : AbstractValidator<ContactViewModel>
    {
        public ContactValidators()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithName("Email");
            RuleFor(x => x.FullName)
               .NotEmpty()
               .NotNull()
               .WithName("İsim");
            RuleFor(x => x.Message)
               .NotEmpty()
               .NotNull()
               .MaximumLength(600)
               .MinimumLength(1)
               .WithName("Mesaj");
            RuleFor(x => x.Subject)
               .NotEmpty()
               .NotNull()
               .MaximumLength(200)
               .MinimumLength(1)
               .WithName("Konu");
        }
    }
}
