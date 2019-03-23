using Shopy.Api.Entities;
using System;
using System.Data.Entity;

namespace Shopy
{
    public class ShopContext : DbContext
    {
        private static Lazy<ShopContext> _current = new Lazy<ShopContext>(
            () => new ShopContext(), isThreadSafe: true);
        public static ShopContext Current
        {
            get
            {
                return _current.Value;
            }
        }

        public virtual DbSet<ProductEF> Products { get; set; }
        public virtual DbSet<CategoryEF> Categories { get; set; }
        public virtual DbSet<SizeTypeEF> SizeTypes { get; set; }
        public virtual DbSet<BrandTypeEF> BrandTypes { get; set; }

        public ShopContext()
            : base("name=shopDBContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //set configuration provider
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}