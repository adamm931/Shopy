using Shopy.Core;
using Shopy.Core.Common;
using Shopy.Core.Data.Entities;
using System.Data.Entity;

namespace Shopy.Data
{
    public class ShopyContext : DbContext
    {
        public virtual DbSet<ProductEF> Products { get; set; }
        public virtual DbSet<CategoryEF> Categories { get; set; }
        public virtual DbSet<SizeTypeEF> SizeTypes { get; set; }
        public virtual DbSet<BrandTypeEF> BrandTypes { get; set; }

        public ShopyContext()
            : base(Constants.ConnectionStringName)
        {
            Database.SetInitializer(new ShopyContextSeeder());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DefaultSchema);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}