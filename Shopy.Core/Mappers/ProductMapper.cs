using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System;

namespace Shopy.Core.Mappers
{
    public class ProductMapper : IMapper<Product, ProductEF>
    {
        public Product FromEF(ProductEF efEntity)
        {
            return new Product()
            {
                Uid = efEntity.Uid,
                Caption = efEntity.Caption,
                Description = efEntity.Description,
                Price = efEntity.Price,
                Brand = efEntity.BrandEId,
                Size = efEntity.SizeEId
            };

        }

        public ProductEF ToEF<TSoure>(Product model)
        {
            throw new NotImplementedException();
        }
    }
}