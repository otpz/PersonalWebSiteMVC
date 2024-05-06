using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Data.Mappings
{
    public class TalentMap : IEntityTypeConfiguration<Talent>
    {
        public void Configure(EntityTypeBuilder<Talent> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(30);

            builder.HasData(
                new Talent
                {
                    Id = 1,
                    Name = "Ofis Araçları",
                    ImageId = 1,
                    CreatedDate = DateTime.Now,
                    Progress = 100,
                    DeletedBy = null,
                    DeletedDate = null,
                    IsDeleted = false,
                    //UserId = 1
                },
                new Talent
                {
                    Id = 2,
                    Name = "VS Code",
                    CreatedDate = DateTime.Now,
                    Progress = 100,
                    ImageId = 2,
                    DeletedBy = null,
                    DeletedDate = null,
                    IsDeleted = false,
                    //UserId = 1
                }
            );

        }
    }
}
