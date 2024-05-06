using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalWebSiteMVC.Data.Repositories.Abstractions;
using PersonalWebSiteMVC.Data.Repositories.Concretes;

namespace PersonalWebSiteMVC.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;  
        }
    }
}
