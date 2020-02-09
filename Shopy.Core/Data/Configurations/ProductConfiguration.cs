using Shopy.Core.Domain.Entitties;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Core.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasRequired(p => p.BrandType)
               .WithMany(p => p.Products)
               .HasForeignKey(p => p.BrandTypeId);

            HasMany(model => model.Categories)
                .WithMany(c => c.Products)
                .Map(t =>
                {
                    t.MapLeftKey("ProductId");
                    t.MapRightKey("CategoryId");
                    t.ToTable("ProductCategories");
                });

            HasMany(p => p.Sizes)
                .WithMany(c => c.Products)
                .Map(t =>
                {
                    t.MapLeftKey("ProductId");
                    t.MapRightKey("SizeId");
                    t.ToTable("ProductSizes");
                });
        }
    }
}