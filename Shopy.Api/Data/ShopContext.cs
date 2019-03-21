using Shopy.Api.Data.Models;
using System;
using System.Data.Entity;

namespace Shopy.Api.Data
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

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SizeType> SizeTypes { get; set; }
        public virtual DbSet<BrandType> BrandTypes { get; set; }

        public ShopContext()
            : base("name=shopDBContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //set configuration provider
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            //modelBuilder.Entity<Student>()
            //    .HasMany<Course>(s => s.Courses)
            //    .WithMany(c => c.Students)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentRefId");
            //        cs.MapRightKey("CourseRefId");
            //        cs.ToTable("StudentCourse");
            //    });

            //modelBuilder.Entity<Product>().HasMany<Category>(p => p.Categories).WithMany(c)
            //    .Has
            base.OnModelCreating(modelBuilder);
        }
    }
}