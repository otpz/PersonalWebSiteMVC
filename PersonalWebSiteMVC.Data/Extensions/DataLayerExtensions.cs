using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalWebSiteMVC.Data.Context;
using PersonalWebSiteMVC.Data.Repositories.Abstractions;
using PersonalWebSiteMVC.Data.Repositories.Concretes;
using PersonalWebSiteMVC.Data.UnitOfWorks;

namespace PersonalWebSiteMVC.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;  
        }
    }
}
