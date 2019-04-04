using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System;
using System.Linq;

namespace Shopy.Core.Mappers
{
    public class ProductMapper : IMapper<Product, ProductEF>
    {
        private CategoryMapper _categoryMapper;

        public ProductMapper(CategoryMapper categoryMapper = null)
        {
            _categoryMapper = categoryMapper;
        }

        public Product FromEF(ProductEF efEntity)
        {
            var product = new Product()
            {
                Uid = efEntity.Uid,
                ProductId = efEntity.ProductId,
                Caption = efEntity.Caption,
                Description = efEntity.Description,
                Price = efEntity.Price,
                Brand = efEntity.BrandEId,
                Sizes = efEntity.Sizes.Select(s => s.SizeTypeEID)
            };

            if (_categoryMapper != null)
            {
                product.Categories = efEntity.Categories.Select(c => _categoryMapper.FromEF(c));
            }

            return product;
        }

        public ProductEF ToEF<TSoure>(Product model)
        {
            throw new NotImplementedException();
        }
    }
}