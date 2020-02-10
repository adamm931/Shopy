using Shopy.Core.Common;
using Shopy.Core.Domain.Entitties.Base;
using Shopy.Core.Domain.Entitties.Enumerations;
using Shopy.Core.Domain.Entitties.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Core.Domain.Entitties
{
    public class Product : NameEntity, IUid
    {
        // private readonly List<SizeType> sizes;

        // private readonly List<Category> categories;

        private IEnumerable<Product> _relatedProducts;

        private const int RelatedProductsLimit = 4;

        public Guid Uid { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public BrandTypeId BrandTypeId { get; private set; }

        public BrandType BrandType { get; private set; }

        public ICollection<SizeType> Sizes { get; private set; }

        // TODO: See how to use private fields with in EF 6
        public ICollection<Category> Categories { get; private set; }

        public IEnumerable<Product> RelatedProducts => _relatedProducts ??= GetRelatedProducts();

        public Product(Guid uid, string name, string description, decimal price) : base(name)
        {
            Uid = uid;
            SetDescription(description);
            SetPrice(price);

            Sizes = new List<SizeType>();
            Categories = new List<Category>();
        }

        private Product()
        {
        }

        public void Update(string name, string description, decimal? price, BrandType brandType, IEnumerable<SizeType> sizeTypes)
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetBrand(brandType);
            SetSizes(sizeTypes);
        }

        public void SetPrice(decimal? price)
        {
            if (!price.HasValue)
            {
                return;
            }

            Price = price.Value;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return;
            }

            Description = description;
        }

        public void SetBrand(BrandType brandType)
        {
            BrandType = brandType;
        }

        public void AddCategory(Category categoryToAdd)
        {
            if (Categories.Any(category => category.Uid == categoryToAdd.Uid))
            {
                return;
            }

            Categories.Add(categoryToAdd);
        }

        public void RemoveCategory(Guid uid)
        {
            Categories.RemoveAll(category => category.Uid == uid);
        }

        public void AddSize(SizeType sizeType)
        {
            if (Sizes.Any(size => size.Id == sizeType.Id))
            {
                return;
            }

            Sizes.Add(sizeType);
        }

        public void RemoveSize(SizeTypeId sizeTypeId)
        {
            Sizes.RemoveAll(size => size.Id == sizeTypeId);
        }

        public void SetSizes(IEnumerable<SizeType> sizeTypes)
        {
            if (sizeTypes == null || !sizeTypes.Any())
            {
                return;
            }

            Sizes.Clear();

            foreach (var sizeType in sizeTypes)
            {
                Sizes.Add(sizeType);
            }
        }

        private IEnumerable<Product> GetRelatedProducts()
        {
            return Categories
                .SelectMany(category => category.Products)
                .Where(product => product.Uid != Uid)
                .Randomize()
                .Take(RelatedProductsLimit);
        }
    }
}