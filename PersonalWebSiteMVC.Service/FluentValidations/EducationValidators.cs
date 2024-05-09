using FluentValidation;
using PersonalWebSiteMVC.Entity.ViewModels.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class EducationValidators : AbstractValidator<EducationAddViewModel>
    {
        public EducationValidators()
        {
            RuleFor(x => x.Title)
                 .NotEmpty()
                 .MinimumLength(1)
                 .NotNull()
                 .MaximumLength(50)
                 .WithName("Eğitim Başlığı");

            RuleFor(x => x.Year)
                .NotEmpty()
                .MinimumLength(4)
                .NotNull()
                .WithName("Eğitim Yılları");

            RuleFor(x => x.Address)
                .NotEmpty()
                .MinimumLength(4)
                .NotNull()
                .WithName("Eğitim Yeri");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(600)
                .NotNull()
                .WithName("Eğitim Yeri");
        }
    }
}
