using System.Data.Entity.ModelConfiguration;

namespace Shopy.Api.Entities.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<CategoryEF>
    {
        public CategoryConfiguration()
        {
            this.ToTable("category")
                .HasKey(p => p.Uid);

            this.Property(p => p.Uid)
                .HasColumnName("uid");

            this.Property(p => p.CategoryID)
                .HasColumnName("category_id")
                .IsRequired();
            //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Caption)
                .HasColumnName("caption")
                .IsRequired();
        }
    }
}