using Shopy.Core;
using Shopy.Core.Common;
using Shopy.Core.Domain.Entitties;
using System.Data.Entity;

namespace Shopy.Data
{
    public class ShopyContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SizeType> SizeTypes { get; set; }
        public virtual DbSet<BrandType> BrandTypes { get; set; }

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