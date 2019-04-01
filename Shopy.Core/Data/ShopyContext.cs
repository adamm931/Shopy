using Shopy.Core;
using Shopy.Core.Common;
using Shopy.Core.Data.Entities;
using System;
using System.Data.Entity;

namespace Shopy.Data
{
    public class ShopyContext : DbContext
    {
        private static Lazy<ShopyContext> _current = new Lazy<ShopyContext>(
            () => new ShopyContext(), isThreadSafe: true);

        public static ShopyContext Current
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
        public virtual DbSet<ImageEF> Images { get; set; }

        public ShopyContext()
            : base(Constants.ConnectionStringName)
        {
            Database.SetInitializer(new ShopyContextSeeder());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //set configuration provider
            modelBuilder.HasDefaultSchema(Constants.DefaultSchema);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void AddSequence(string sequenceName, int begin)
        {
            var sqlTemplate = $"CREATE SEQUENCE {sequenceName} START {begin};";
            Database.ExecuteSqlCommand(sqlTemplate);
        }

        public long GetValueFromSequence(string sequenceName)
        {
            long result;

            var connection = Database.Connection;

            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT nextval('{sequenceName}')";
                connection.Open();
                result = (long)command.ExecuteScalar();
                connection.Close();
            }

            return result;
        }
    }
}