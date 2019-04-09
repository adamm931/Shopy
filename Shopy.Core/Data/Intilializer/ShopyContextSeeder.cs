using Shopy.Core.Data.Entities;
using Shopy.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Shopy.Core
{
    public class ShopyContextSeeder : CreateDatabaseIfNotExists<ShopyContext>
    {
        protected override void Seed(ShopyContext dbContext)
        {
            //standalone models
            var products = GetProducts();
            var categoires = GetCategories();
            var brandTypes = GetBrandTypes();
            var sizeTypes = GetSizeTypes();

            //define categories
            var tShirts = categoires["T-shirts"];
            var jackets = categoires["Jackets"];
            var footwear = categoires["Footwear"];
            var shoes = categoires["Shoes"];
            var clothes = categoires["Clothes"];

            //define brands
            var active = brandTypes["AC"];
            var addidas = brandTypes["AD"];
            var rebook = brandTypes["RB"];
            var nike = brandTypes["NK"];

            //define sizes
            var s = sizeTypes["S"];
            var m = sizeTypes["M"];
            var l = sizeTypes["L"];
            var xl = sizeTypes["XL"];

            //products categories
            products[0].Categories.AddRange(new[] { footwear, shoes });
            products[1].Categories.AddRange(new[] { clothes, tShirts });
            products[2].Categories.AddRange(new[] { jackets, clothes });
            products[3].Categories.AddRange(new[] { jackets, clothes });
            products[4].Categories.AddRange(new[] { jackets, clothes });
            products[5].Categories.AddRange(new[] { footwear, shoes });
            products[6].Categories.AddRange(new[] { jackets, tShirts });
            products[7].Categories.AddRange(new[] { clothes, tShirts });
            products[8].Categories.AddRange(new[] { clothes, tShirts });
            products[9].Categories.AddRange(new[] { clothes, tShirts });
            products[10].Categories.AddRange(new[] { clothes, jackets });
            products[11].Categories.AddRange(new[] { footwear, shoes });
            products[12].Categories.AddRange(new[] { footwear, shoes });
            products[13].Categories.AddRange(new[] { clothes, tShirts });

            //products sizes
            products[0].Sizes.AddRange(new[] { s, m, l });
            products[1].Sizes.AddRange(new[] { m, l, xl });
            products[2].Sizes.AddRange(new[] { s, m });
            products[3].Sizes.AddRange(new[] { m, l, xl });
            products[4].Sizes.AddRange(new[] { xl, l });
            products[5].Sizes.AddRange(new[] { s, m, l });
            products[6].Sizes.AddRange(new[] { s, m, xl });
            products[7].Sizes.AddRange(new[] { xl, s });
            products[8].Sizes.AddRange(new[] { s, l });
            products[9].Sizes.AddRange(new[] { s, m, l });
            products[10].Sizes.AddRange(new[] { s, l, xl });
            products[11].Sizes.AddRange(new[] { m, l });
            products[12].Sizes.AddRange(new[] { l, xl });
            products[13].Sizes.AddRange(new[] { s, xl, m });

            //products brands
            products[0].Brand = active;
            products[1].Brand = nike;
            products[2].Brand = rebook;
            products[3].Brand = addidas;
            products[4].Brand = active;
            products[5].Brand = nike;
            products[6].Brand = rebook;
            products[7].Brand = addidas;
            products[8].Brand = active;
            products[9].Brand = nike;
            products[10].Brand = rebook;
            products[11].Brand = addidas;
            products[12].Brand = active;
            products[13].Brand = nike;

            //products
            dbContext.Products.AddRange(products);

            //categories
            dbContext.Categories.AddRange(categoires.Values);

            //sizes
            dbContext.BrandTypes.AddRange(brandTypes.Values);

            //brands
            dbContext.SizeTypes.AddRange(sizeTypes.Values);

            //save
            dbContext.SaveChanges();
        }

        private static ProductEF[] GetProducts()
        {
            return new[]
            {
                //0
                new ProductEF()
                {
                    Uid = new Guid("0f485e38-92d5-49f0-8ed3-b2550f2f04f5"),
                    Caption = "White sneackers addidas",
                    Price = 100.5m,
                    Description = "White sneackers addidas",
                },
                //1
                new ProductEF()
                {
                    Uid = new Guid("1bc0dae4-b4f1-4144-b2f5-607f5e685767"),
                    Caption = "T-shirts for boys",
                    Price = 40m,
                    Description = "Blue yellow and black shirst"
                },
                //2
                new ProductEF()
                {
                    Uid = new Guid("1e01864c-79a4-4af2-a99f-0398e583349e"),
                    Caption = "Jackets",
                    Price = 140.25m,
                    Description = "Green jackets for a man",
                },
                //3
                new ProductEF()
                {
                    Uid = new Guid("41ec1d4a-372b-4774-af20-21be451a2c99"),
                    Caption = "Fancy jackets",
                    Price = 120.5m,
                    Description = "Brown and black fancy jackets"
                },
                //4
                new ProductEF()
                {
                    Uid = new Guid("47aa7d6a-a178-4c2d-8812-9218db301f39"),
                    Caption = "Winter jacket black",
                    Price = 130.5m,
                    Description = "Winter jacket black"
                },
                //5
                new ProductEF()
                {
                    Uid = new Guid("57066b95-3265-47f3-91bd-bbbb26d8359c"),
                    Caption = "Sneakers",
                    Price = 90.5m,
                    Description = "Original white addidas sneakers",
                },
                //6
                new ProductEF()
                {
                    Uid = new Guid("67542922-4b0c-4e5a-9a0f-753798747815"),
                    Caption = "T-shirt black jacket kit",
                    Price = 80.5m,
                    Description = "-shirt black jacket kit"
                },
                //7
                new ProductEF()
                {
                    Uid = new Guid("a5779a04-5fa6-42e3-8793-8f8569922bbc"),
                    Caption = "Girls sweat rose shirts",
                    Price = 20.5m,
                    Description = "Girls sweat rose shirts"
                },
                //8
                new ProductEF()
                {
                    Uid = new Guid("ab52ab5b-3dea-4b4b-8436-2de9ef8eb346"),
                    Caption = "Thirts white and blue",
                    Price = 22.5m,
                    Description = "Thirts white and blue"
                },
                //9
                new ProductEF()
                {
                    Uid = new Guid("c4791738-9b3f-4828-9303-f50d9e1dde01"),
                    Caption = "Tshrits rozes for women",
                    Price = 23.5m,
                    Description = "Tshrits rozes for women"
                },
                //10
                new ProductEF()
                {
                    Uid = new Guid("e5f5d746-6c5d-4f3d-8e72-d25265e48b5b"),
                    Caption = "Suits",
                    Price = 130.5m,
                    Description = "Nice suits for a real mans"
                },
                //11
                new ProductEF()
                {
                    Uid = new Guid("ec59112c-71bf-429d-9036-110c640bc9e5"),
                    Caption = "Brown man shoes",
                    Price = 152.5m,
                    Description = "Elegant shoes for all part of the day"
                },
                //12
                new ProductEF()
                {
                    Uid = new Guid("f562c840-cc8d-414a-aeeb-eec8a2602db6"),
                    Caption = "Black man shoes",
                    Price = 150.5m,
                    Description = "Elegant shoes for all part of the day"
                },
                //13
                new ProductEF()
                {
                    Uid = new Guid("fe384831-ef32-483f-a4b2-6d8796949a1d"),
                    Caption = "Elegant polo shirts",
                    Price = 37.5m,
                    Description = "Elegant polo shirts"
                }
            };
        }

        private Dictionary<string, CategoryEF> GetCategories()
        {
            var retVal = new Dictionary<string, CategoryEF>();
            retVal.Add("Shoes", new CategoryEF() { Uid = Guid.NewGuid(), Caption = "Shoes" });
            retVal.Add("Jackets", new CategoryEF() { Uid = Guid.NewGuid(), Caption = "Jackets" });
            retVal.Add("Clothes", new CategoryEF() { Uid = Guid.NewGuid(), Caption = "Clothes" });
            retVal.Add("Footwear", new CategoryEF() { Uid = Guid.NewGuid(), Caption = "Footwear" });
            retVal.Add("T-shirts", new CategoryEF() { Uid = Guid.NewGuid(), Caption = "T-shirts" });

            return retVal;
        }

        private Dictionary<string, BrandTypeEF> GetBrandTypes()
        {
            var result = new Dictionary<string, BrandTypeEF>();
            result.Add("AC", new BrandTypeEF() { BrandTypeEId = "AC", Caption = "Active" });
            result.Add("AD", new BrandTypeEF() { BrandTypeEId = "AD", Caption = "Addidas" });
            result.Add("NK", new BrandTypeEF() { BrandTypeEId = "NK", Caption = "Nike" });
            result.Add("RB", new BrandTypeEF() { BrandTypeEId = "RB", Caption = "Rebook" });
            return result;
        }

        private Dictionary<string, SizeTypeEF> GetSizeTypes()
        {
            var result = new Dictionary<string, SizeTypeEF>();
            result.Add("S", new SizeTypeEF() { SizeTypeEID = "S", Caption = "Small" });
            result.Add("M", new SizeTypeEF() { SizeTypeEID = "M", Caption = "Medium" });
            result.Add("L", new SizeTypeEF() { SizeTypeEID = "L", Caption = "Large" });
            result.Add("XL", new SizeTypeEF() { SizeTypeEID = "XL", Caption = "X Large" });
            return result;
        }
    }
}