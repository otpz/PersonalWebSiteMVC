using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalWebSiteMVC.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Data.Mappings
{
    public class SocialMediaMap : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {

            builder.HasData(
                new SocialMedia
                {
                    Id = 1,
                    Title = "LinkedIn", 
                    Url = "https://linkedin.com/user",
                    ImageId = 3,
                    CreatedDate = DateTime.Now,
                    DeletedDate = null,
                    DeletedBy = null,
                    IsDeleted = false,
                }
            );

        }
    }
}
