using Shopy.Api.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Api.Data.Configurations
{
    public class ImageEFConfiguration : EntityTypeConfiguration<ImageEF>
    {
        public ImageEFConfiguration()
        {
            this.ToTable("image")
                .HasKey(b => b.Uid);

            this.Property(b => b.Name)
                .HasColumnName("name")
                .IsRequired();

            this.Property(b => b.Url)
                .HasColumnName("url")
                .IsRequired();
        }
    }
}