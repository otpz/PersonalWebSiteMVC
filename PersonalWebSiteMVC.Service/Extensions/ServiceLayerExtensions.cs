using Microsoft.Extensions.DependencyInjection;
using PersonalWebSiteMVC.Service.Helpers.Images;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Service.Services.Concretes;
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

            return services;
        }
        
    }
}
