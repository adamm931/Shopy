using Shopy.Api.Entities;
using System;
using System.Linq;

namespace Shopy
{
    public class DatabaseSeeder
    {
        public static void Seed()
        {
            var dbContext = new ShopContext();

            //if (dbContext.Database.Exists())
            //{
            //    return;
            //}


            //dbContext.Database.Delete();
            //dbContext.Database.Create();

            dbContext.Database.CreateIfNotExists();

            //standlone models
            var products = GetProducts();
            var categoires = GetCategories();
            var brandTypes = GetBrandTypes();
            var sizeTypes = GetSizeTypes();

            //products
            products[0].Categories.Add(categoires[0]);
            products[1].Categories.Add(categoires[2]);
            products[2].Categories.AddRange(new[] { categoires[1], categoires[2] });
            dbContext.Products.AddRange(products);

            //categories
            categoires[0].Products.Add(products[2]);
            categoires[1].Products.AddRange(new[] { products[0], products[1] });
            dbContext.Categories.AddRange(categoires);

            //sizes
            dbContext.BrandTypes.AddRange(brandTypes);

            //brands
            dbContext.SizeTypes.AddRange(sizeTypes);

            //products sizes
            sizeTypes[0].Products.Add(products[0]);
            products[0].Size = sizeTypes[0];

            sizeTypes[1].Products.AddRange(new[] { products[1], products[2] });
            products[1].Size = sizeTypes[1];
            products[2].Size = sizeTypes[1];

            //products brands
            brandTypes[0].Products.Add(products[0]);
            products[0].Brand = brandTypes[0];

            brandTypes[1].Products.AddRange(new[] { products[1], products[2] });
            products[1].Brand = brandTypes[1];
            products[2].Brand = brandTypes[1];

            //save
            dbContext.SaveChanges();
        }

        private static ProductEF[] GetProducts()
        {
            return new[]
            {
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "test123",
                    Price = 12.5m,
                    Description = "Description 1"
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "test1234",
                    Price = 13.5m,
                    Description = "Description 2"
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "test1235",
                    Price = 14.5m,
                    Description = "Description 3",
                }
            };
        }

        private static CategoryEF[] GetCategories()
        {
            return new[]
            {
                new CategoryEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "category1"
                },
                new CategoryEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "category2"
                },
                new CategoryEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "category3"
                }
            };
        }

        private static string[] brands = new[] {
            "Puma",
            "Addiddas",
            "Nike",
            "Champion",
            "Rebook"};

        private static string[] sizes = new[] {
            "S",
            "M",
            "L",
            "XL",
            "XXL"};


        private static BrandTypeEF[] GetBrandTypes()
        {
            return brands.Select(b =>
                new BrandTypeEF()
                {
                    BrandTypeEId = Guid.NewGuid(),
                    Caption = b
                })
                .ToArray();
        }

        private static SizeTypeEF[] GetSizeTypes()
        {
            return sizes.Select(s =>
                new SizeTypeEF()
                {
                    SizeTypeEID = Guid.NewGuid(),
                    Caption = s
                })
                .ToArray();
        }
    }
}