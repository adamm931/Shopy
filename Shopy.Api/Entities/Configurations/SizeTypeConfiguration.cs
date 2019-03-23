using System.Data.Entity.ModelConfiguration;

namespace Shopy.Api.Entities.Configurations
{
    public class SizeTypeConfiguration : EntityTypeConfiguration<SizeTypeEF>
    {
        public SizeTypeConfiguration()
        {
            this.ToTable("size_type")
                .HasKey(s => s.SizeTypeEID);

            this.Property(s => s.SizeTypeEID)
                .HasColumnName("size_type_eid");

            this.Property(s => s.Caption)
                .HasColumnName("caption")
                .IsRequired();
        }
    }
}