using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System;
using System.Linq;

namespace Shopy.Core.Mappers
{
    public class ProductMapper : IMapper<Product, ProductEF>
    {
        private SizeMapper sizeMapper = new SizeMapper();

        public Product FromEF(ProductEF efEntity)
        {
            return new Product()
            {
                Uid = efEntity.Uid,
                ProductId = efEntity.ProductId,
                Caption = efEntity.Caption,
                Description = efEntity.Description,
                Price = efEntity.Price,
                Brand = efEntity.BrandEId,
                Sizes = efEntity.Sizes.Select(s => sizeMapper.FromEF(s))
            };
        }

        public ProductEF ToEF<TSoure>(Product model)
        {
            throw new NotImplementedException();
        }
    }
}