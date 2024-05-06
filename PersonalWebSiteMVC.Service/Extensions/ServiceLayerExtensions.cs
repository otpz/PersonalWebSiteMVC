using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
        
    }
}
