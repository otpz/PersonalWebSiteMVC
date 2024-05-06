using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
            new Image
            {
                Id = 1,
                FileName = "images/ofis-araclari",
                FileType = "jpg",
                DeletedBy = null,
                DeletedDate = null,
                IsDeleted = false,
            },
            new Image
            {
                Id = 2,
                FileName = "images/vs-code",
                FileType = "jpg",
                DeletedBy = null,
                DeletedDate = null,
                IsDeleted = false,
            },
            new Image
            {
                Id = 3,
                FileName = "images/linked-in",
                FileType = "png",
                DeletedBy = null,
                DeletedDate = null,
                IsDeleted = false,
            });
        }
    }
}
