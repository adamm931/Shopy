using Shopy.Core.Common;
using Shopy.Core.Data.Entities;
using Shopy.Core.Data.Entities.Enums;
using Shopy.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace Shopy.Core
{
    public class ShopyContextSeeder : IDatabaseInitializer<ShopyContext>
    {
        private static SizeTypeEF[] Sizes = GetSizeTypes();
        private static ProductEF[] Products = GetProducts();
        private static CategoryEF[] Categories = GetCategories();
        private static BrandTypeEF[] Brands = GetBrandTypes();

        public void InitializeDatabase(ShopyContext dbContext)
        {
            if (!dbContext.Database.CreateIfNotExists())
            {
                return;
            }

            //standalone models
            var products = GetProducts();
            var categoires = GetCategories();
            var brandTypes = GetBrandTypes();
            var sizeTypes = GetSizeTypes();

            dbContext.AddSequence(Constants.ProductsSerial, 1);

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
            sizeTypes[0].Products.AddRange(new[] { products[0], products[7] });
            products[0].Size = sizeTypes[0];
            products[7].Size = sizeTypes[0];

            sizeTypes[1].Products.AddRange(new[] { products[1], products[2] });
            products[1].Size = sizeTypes[1];
            products[2].Size = sizeTypes[1];

            sizeTypes[2].Products.AddRange(new[] { products[3], products[5] });
            products[3].Size = sizeTypes[2];
            products[5].Size = sizeTypes[2];

            sizeTypes[3].Products.AddRange(new[] { products[4], products[6] });
            products[4].Size = sizeTypes[3];
            products[6].Size = sizeTypes[3];


            //products brands
            brandTypes[0].Products.AddRange(new[] { products[0], products[4] });
            products[0].Brand = brandTypes[0];
            products[4].Brand = brandTypes[0];

            brandTypes[1].Products.AddRange(new[] { products[1], products[5] });
            products[1].Brand = brandTypes[1];
            products[5].Brand = brandTypes[1];

            brandTypes[2].Products.AddRange(new[] { products[2], products[6] });
            products[2].Brand = brandTypes[2];
            products[6].Brand = brandTypes[2];

            brandTypes[3].Products.AddRange(new[] { products[3], products[7] });
            products[3].Brand = brandTypes[3];
            products[7].Brand = brandTypes[3];

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
                    Caption = "Jacket",
                    Price = 12.5m,
                    Description = "Winter jacket",
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Jacket",
                    Price = 13.5m,
                    Description = "Summer jacket"
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Jacket small",
                    Price = 14.5m,
                    Description = "Summer jacket small",
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Shoes big",
                    Price = 12.5m,
                    Description = "Shoes big size"
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "TShirt",
                    Price = 13.5m,
                    Description = "Red tshirt summer edition"
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Jeanse levis small",
                    Price = 14.5m,
                    Description = "Original levis small jeans",
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "TShirt large",
                    Price = 12.5m,
                    Description = "TShirst large summer"
                },
                new ProductEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Belt",
                    Price = 13.5m,
                    Description = "Platinum belt from all purposes"
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
                    Caption = "Shoes"
                },
                new CategoryEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Jackets"
                },
                new CategoryEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "TShirts"
                },
                new CategoryEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Clothes"
                },
                new CategoryEF()
                {
                    Uid = Guid.NewGuid(),
                    Caption = "Footwear"
                }
            };
        }

        private static BrandTypeEF[] GetBrandTypes()
        {
            return new[] {

                new BrandTypeEF()
                {
                    BrandTypeEId = BrandType.Active,
                    Caption = "Active"
                },
                new BrandTypeEF()
                {
                    BrandTypeEId = BrandType.Addidas,
                    Caption = "Addidas"
                },
                new BrandTypeEF()
                {
                    BrandTypeEId = BrandType.Nike,
                    Caption = "Nike"
                },
                new BrandTypeEF()
                {
                    BrandTypeEId = BrandType.Rebook,
                    Caption = "Rebook"
                }
            };
        }

        private static SizeTypeEF[] GetSizeTypes()
        {
            var size = new[] {

                new SizeTypeEF()
                {
                    SizeTypeEID = SizeType.S,
                    Caption = "Small"
                },
                new SizeTypeEF()
                {
                    SizeTypeEID = SizeType.M,
                    Caption = "Medium"
                },
                new SizeTypeEF()
                {
                    SizeTypeEID = SizeType.L,
                    Caption = "Large"
                },
                new SizeTypeEF()
                {
                    SizeTypeEID = SizeType.XL,
                    Caption = "X Large"
                }
            };

            return size;
        }

        private SizeTypeEF GetSize(SizeType type)
        {
            return Sizes.Single(s => s.SizeTypeEID == type);
        }

        private BrandTypeEF GetBrand(BrandType type)
        {
            return Brands.Single(s => s.BrandTypeEId == type);
        }

        private CategoryEF GetCategory(string caption)
        {
            return Categories.Single(c => c.Caption == caption);
        }
    }
}