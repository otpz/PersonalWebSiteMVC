using FluentValidation;
using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class TestimonialValidators : AbstractValidator<Testimonial>
    {
        public TestimonialValidators()
        {
            RuleFor(x => x.FirstName)
                 .NotEmpty()
                 .MinimumLength(1)
                 .NotNull()
                 .MaximumLength(50)
                 .WithName("Adı");

            RuleFor(x => x.LastName)
                .NotEmpty()
                 .MinimumLength(1)
                 .NotNull()
                 .MaximumLength(50)
                 .WithName("Soyadı");

            RuleFor(x => x.Job)
                .NotEmpty()
                 .MinimumLength(1)
                 .NotNull()
                 .MaximumLength(50)
                 .WithName("Meslek");

            RuleFor(x => x.Message)
                 .NotEmpty()
                 .NotNull()
                 .MaximumLength(600)
                 .MinimumLength(10)
                 .WithName("Mesaj");

        }
    }
}
