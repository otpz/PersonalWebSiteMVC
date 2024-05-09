using FluentValidation;
using PersonalWebSiteMVC.Entity.ViewModels.Users;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class UserProfileValidatiors : AbstractValidator<UserViewModel>
    {
        public UserProfileValidatiors()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .MinimumLength(2)
                .WithName("İsim");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .MinimumLength(2)
                .WithName("Soyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithName("Email");

            RuleFor(x => x.PhoneNumber)
               .NotEmpty()
               .NotNull()
               .MaximumLength(13)
               .MinimumLength(10)
               .WithName("Telefon No.");

            RuleFor(x => x.Birthday)
               .NotEmpty()
               .NotNull()
               .WithName("Doğum Günü");

            RuleFor(x => x.Website)
               .NotEmpty()
               .NotNull()
               .WithName("Web Sitesi");

            RuleFor(x => x.City)
              .NotEmpty()
              .NotNull()
              .MaximumLength(20)
              .MinimumLength(2)
              .WithName("Ülke | Şehir");

            RuleFor(x => x.Address)
              .NotEmpty()
              .NotNull()
              .MaximumLength(100)
              .MinimumLength(2)
              .WithName("Adres");

            RuleFor(x => x.Degree)
              .NotEmpty()
              .NotNull()
              .MaximumLength(50)
              .MinimumLength(2)
              .WithName("Derece");

            RuleFor(x => x.Description)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .WithName("Açıklama Özet");

            RuleFor(x => x.Title)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .WithName("Meslek | Başlık");
        }
    }
}
