using Shopy.Core.Data.Extensions;
using Shopy.Core.Domain.Entitties;
using Shopy.Core.Domain.Entitties.Enumerations;
using Shopy.Data;
using System;
using System.Data.Entity;

namespace Shopy.Core
{
    internal class ShopyContextSeeder : CreateDatabaseIfNotExists<ShopyContext>
    {
        protected override void Seed(ShopyContext dbContext)
        {
            //define products
            var products = GetProducts();

            //define categories
            var tShirts = new Category("T-shirts");
            var jackets = new Category("Jackets");
            var footwear = new Category("Footwear");
            var shoes = new Category("Shoes");
            var clothes = new Category("Clothes");

            //define brands
            var active = BrandType.From(BrandTypeId.Active);
            var addidas = BrandType.From(BrandTypeId.Addidas);
            var rebook = BrandType.From(BrandTypeId.Rebook);
            var nike = BrandType.From(BrandTypeId.Nike);
            var puma = BrandType.From(BrandTypeId.Puma);

            //define sizes
            var xs = SizeType.From(SizeTypeId.XS);
            var s = SizeType.From(SizeTypeId.S);
            var m = SizeType.From(SizeTypeId.M);
            var l = SizeType.From(SizeTypeId.L);
            var xl = SizeType.From(SizeTypeId.XL);

            //products categories
            products[0].AddCategory(footwear);
            products[0].AddCategory(shoes);

            products[1].AddCategory(jackets);
            products[1].AddCategory(clothes);

            products[2].AddCategory(jackets);
            products[2].AddCategory(clothes);

            products[3].AddCategory(jackets);
            products[3].AddCategory(clothes);

            products[4].AddCategory(jackets);
            products[4].AddCategory(clothes);

            products[5].AddCategory(footwear);
            products[5].AddCategory(shoes);

            products[6].AddCategory(jackets);
            products[6].AddCategory(tShirts);

            products[7].AddCategory(clothes);
            products[7].AddCategory(tShirts);

            products[8].AddCategory(clothes);
            products[8].AddCategory(tShirts);

            products[9].AddCategory(clothes);
            products[9].AddCategory(tShirts);

            products[10].AddCategory(clothes);
            products[10].AddCategory(jackets);

            products[11].AddCategory(footwear);
            products[11].AddCategory(shoes);

            products[12].AddCategory(footwear);
            products[12].AddCategory(shoes);

            products[13].AddCategory(clothes);
            products[13].AddCategory(tShirts);

            //products sizes
            products[0].AddSize(xs);
            products[0].AddSize(s);
            products[0].AddSize(m);

            products[1].AddSize(m);
            products[1].AddSize(l);
            products[1].AddSize(xl);

            products[2].AddSize(s);
            products[2].AddSize(m);

            products[3].AddSize(xs);
            products[3].AddSize(l);
            products[3].AddSize(xl);

            products[4].AddSize(l);
            products[4].AddSize(xl);

            products[5].AddSize(s);
            products[5].AddSize(l);
            products[5].AddSize(xs);

            products[6].AddSize(s);
            products[6].AddSize(m);
            products[6].AddSize(xl);

            products[7].AddSize(xl);
            products[7].AddSize(s);

            products[8].AddSize(s);
            products[8].AddSize(l);

            products[9].AddSize(s);
            products[9].AddSize(l);
            products[9].AddSize(m);

            products[10].AddSize(s);
            products[10].AddSize(l);
            products[10].AddSize(xl);

            products[11].AddSize(m);
            products[11].AddSize(l);

            products[12].AddSize(l);
            products[12].AddSize(xl);

            products[13].AddSize(s);
            products[13].AddSize(xl);
            products[13].AddSize(m);

            //products brands
            products[0].SetBrand(active);
            products[1].SetBrand(nike);
            products[2].SetBrand(rebook);
            products[3].SetBrand(addidas);
            products[4].SetBrand(active);
            products[5].SetBrand(nike);
            products[6].SetBrand(rebook);
            products[7].SetBrand(addidas);
            products[8].SetBrand(active);
            products[9].SetBrand(puma);
            products[10].SetBrand(rebook);
            products[11].SetBrand(addidas);
            products[12].SetBrand(puma);
            products[13].SetBrand(nike);

            //add products
            dbContext.Products.AddRange(products);

            //save
            dbContext.SaveChanges();
        }

        private static Product[] GetProducts()
        {
            return new[]
            {
                //0
                new Product
                (
                    new Guid("0f485e38-92d5-49f0-8ed3-b2550f2f04f5"),
                    "White sneackers addidas",
                    "White sneackers addidas",
                    100.5m
                ),
                //1
                new Product
                (
                    new Guid("1bc0dae4-b4f1-4144-b2f5-607f5e685767"),
                    "T-shirts for boys",
                    "Blue yellow and black shirst",
                    40m
                ),
                //2
                new Product
                (
                    new Guid("1e01864c-79a4-4af2-a99f-0398e583349e"),
                    "Jackets",
                    "Green jackets for a man",
                    140.25m
                    ),
                //3
                new Product
                (
                    new Guid("41ec1d4a-372b-4774-af20-21be451a2c99"),
                    "Fancy jackets",
                    "Brown and black fancy jackets",
                    120.5m
                ),
                //4
                new Product
                (
                    new Guid("47aa7d6a-a178-4c2d-8812-9218db301f39"),
                    "Winter jacket black",
                    "Winter jacket black",
                    130.5m
                ),
                //5
                new Product
                (
                    new Guid("57066b95-3265-47f3-91bd-bbbb26d8359c"),
                    "Sneakers",
                    "Original white addidas sneakers",
                    90.5m
                ),
                //6
                new Product
                (
                    new Guid("67542922-4b0c-4e5a-9a0f-753798747815"),
                    "T-shirt black jacket kit",
                    "-shirt black jacket kit",
                    80.5m
                ),
                //7
                new Product
                (
                    new Guid("a5779a04-5fa6-42e3-8793-8f8569922bbc"),
                    "Girls sweat rose shirts",
                    "Girls sweat rose shirts",
                    20.5m
                ),
                //8
                new Product
                (
                    new Guid("ab52ab5b-3dea-4b4b-8436-2de9ef8eb346"),
                    "Thirts white and blue",
                    "Thirts white and blue",
                    22.5m
                ),
                //9
                new Product
                (
                    new Guid("c4791738-9b3f-4828-9303-f50d9e1dde01"),
                    "Tshrits rozes for women",
                    "Tshrits rozes for women",
                    23.5m
                ),
                //10
                new Product
                (
                    new Guid("e5f5d746-6c5d-4f3d-8e72-d25265e48b5b"),
                    "Suits",
                    "Nice suits for a real mans",
                    130.5m
                ),
                //11
                new Product
                (
                    new Guid("ec59112c-71bf-429d-9036-110c640bc9e5"),
                    "Brown man shoes",
                    "Elegant shoes for all part of the day",
                    152.5m
                ),
                //12
                new Product
                (
                    new Guid("f562c840-cc8d-414a-aeeb-eec8a2602db6"),
                    "Black man shoes",
                    "Elegant shoes for all part of the day",
                    150.5m
                ),
                //13
                new Product
                (
                    new Guid("fe384831-ef32-483f-a4b2-6d8796949a1d"),
                    "Elegant polo shirts",
                    "Elegant polo shirts",
                    37.5m
                )
            };
        }
    }
}