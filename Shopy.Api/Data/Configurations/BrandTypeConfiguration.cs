using Shopy.Api.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Api.Data.Configurations
{
    public class BrandTypeConfiguration : EntityTypeConfiguration<BrandType>
    {
        public BrandTypeConfiguration()
        {
            this.ToTable("brand_type")
                .HasKey(b => b.BrandTypeEId);

            this.Property(b => b.BrandTypeEId)
                .HasColumnName("brand_type_eid");

            this.Property(b => b.Caption)
                .HasColumnName("caption")
                .IsRequired();
        }
    }
}