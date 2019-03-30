﻿using Shopy.Api.Common;
using Shopy.Api.Entities;
using System;
using System.Data.Entity;

namespace Shopy
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

        public ShopyContext()
            : base(Constants.ConnectionStringName)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //set configuration provider
            modelBuilder.HasDefaultSchema(Constants.DefaultSchema);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            //TODO
            //Database.SetInitializer(new DbContext());

            //add sequnces
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