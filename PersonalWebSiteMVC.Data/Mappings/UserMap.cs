using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var superAdmin = new AppUser
            {
                Id = 1,
                UserName = "osmantopuz98@gmail.com",
                Email = "osmantopuz98@gmail.com",
                FirstName = "Osman",
                LastName = "Topuz",
                NormalizedEmail = "OSMANTOPUZ98@GMAIL.COM",
                NormalizedUserName = "OSMANTOPUZ98@GMAIL.COM",
                PhoneNumber = "05555555555",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = "1",
                Address = "Atatürk Mah. Uşak Merkez",
                Birthday = new DateTime(2000, 03, 10),
                City = "Uşak",
                Degree = "Bachelor of Engineering",
                Description = "Electrical Electronics Engineering & Software Engineering",
                Title = "Electrical Electronics Engineering & Software Engineering",
                Website = "www.devotpz@gmail.com",
            };
            superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "123123asd");

            builder.HasData(
                superAdmin
            );
        }

        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
