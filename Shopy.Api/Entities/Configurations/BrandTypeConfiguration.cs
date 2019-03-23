using System.Data.Entity.ModelConfiguration;

namespace Shopy.Api.Entities.Configurations
{
    public class BrandTypeConfiguration : EntityTypeConfiguration<BrandTypeEF>
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