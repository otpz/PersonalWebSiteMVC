using Microsoft.EntityFrameworkCore;
using PersonalWebSiteMVC.Entity.Entities;
using System.Reflection;

namespace PersonalWebSiteMVC.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Tüm mappingler için yapılan config'leri uygula | IEntityTypeConfiguration<>'dan türemiş tüm sınıflar için geçerlidir.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
