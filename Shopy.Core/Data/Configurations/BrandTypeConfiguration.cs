using Shopy.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Core.Data.Configurations
{
    public class BrandTypeConfiguration : EntityTypeConfiguration<BrandTypeEF>
    {
        public BrandTypeConfiguration()
        {
            this.ToTable("brand_type")
                .HasKey(b => b.BrandTypeEId);

            this.Property(b => b.BrandTypeEId)
                .HasColumnName("eid");

            this.Property(b => b.Caption)
                .HasColumnName("caption")
                .IsRequired();
        }
    }
}