using Shopy.Core;
using Shopy.Core.Common;
using Shopy.Core.Data;
using Shopy.Core.Domain.Entitties;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Shopy.Data
{
    internal class ShopyContext : DbContext, IShopyContext
    {
        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<SizeType> SizeTypes { get; set; }

        public IDbSet<BrandType> BrandTypes { get; set; }

        public ShopyContext() : base(Constants.ConnectionStringName)
        {
            Database.SetInitializer(new ShopyContextSeeder());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DefaultSchema);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task Save()
        {
            await SaveChangesAsync();
        }
    }
}