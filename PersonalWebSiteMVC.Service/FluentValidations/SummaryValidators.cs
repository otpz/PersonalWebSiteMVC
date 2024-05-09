using FluentValidation;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Service.FluentValidations
{
    public class SummaryValidators: AbstractValidator<Summary>
    {
        public SummaryValidators()
        {
            RuleFor(x => x.Description)
                 .NotEmpty()
                 .NotNull()
                 .MaximumLength(600)
                 .MinimumLength(10)
                 .WithName("Özet Açıklaması");
        }
    }
}
