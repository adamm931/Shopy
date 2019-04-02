using Shopy.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Core.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<ProductEF>
    {
        public ProductConfiguration()
        {
            this.ToTable("product")
                .HasKey(p => p.Uid);

            this.Property(p => p.Uid)
                .HasColumnName("uid");

            this.Property(p => p.ProductId)
                .HasColumnName("product_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Price)
                .HasColumnName("price")
                .IsRequired();

            this.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired();

            this.Property(p => p.Caption)
                .HasColumnName("caption")
                .IsRequired();

            this.Property(p => p.BrandEId)
                .HasColumnName("brand_eid")
                .IsRequired();

            this.HasRequired(p => p.Brand)
               .WithMany(p => p.Products)
               .HasForeignKey(p => p.BrandEId);

            this.HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(t =>
                {
                    t.MapLeftKey("fk_product_id");
                    t.MapRightKey("fk_category_id");
                    t.ToTable("product_category");
                });

            this.HasMany(p => p.Sizes)
                .WithMany(c => c.Products)
                .Map(t =>
                {
                    t.MapLeftKey("fk_product_id");
                    t.MapRightKey("fk_size_eid");
                    t.ToTable("product_sizes");
                });
        }
    }
}