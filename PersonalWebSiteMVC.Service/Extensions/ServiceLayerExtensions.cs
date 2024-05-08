using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalWebSiteMVC.Service.FluentValidations;
using PersonalWebSiteMVC.Service.Helpers.Images;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Service.Services.Concretes;
using System.Globalization;
using System.Reflection;

namespace PersonalWebSiteMVC.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITalentService, TalentService>();

            services.AddScoped<IImageHelper, ImageHelper>();
            
            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<TalentValidators>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            return services;
        }
        
    }
}
