using Shopy.Core.Domain.Entitties.Enumerations;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Domain.Entitties.Interfaces
{
    public interface IProduct
    {
        public Guid Uid { get; }

        public string Description { get; }

        public decimal Price { get; }

        public BrandTypeId BrandTypeId { get; }

        public BrandType BrandType { get; }

        public ICollection<SizeType> Sizes { get; }

        public ICollection<Category> Categories { get; }

        public IEnumerable<Product> RelatedProducts { get; }

        void Update(string name, string description, decimal? price, BrandType brandType, IEnumerable<SizeType> sizeTypes);

        void SetPrice(decimal? price);

        void SetDescription(string description);

        void SetBrand(BrandType brandType);

        void AddCategory(Category categoryToAdd);

        void RemoveCategory(Guid uid);

        void AddSize(SizeType sizeType);

        void RemoveSize(SizeTypeId sizeTypeId);

        void SetSizes(IEnumerable<SizeType> sizeTypes);
    }
}
