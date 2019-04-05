using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System;
using System.Linq;

namespace Shopy.Core.Mappers
{
    public class ProductMapper : IMapper<Product, ProductEF>
    {
        private CategoryMapper _categoryMapper;
        private BrandMapper _brandMapper = new BrandMapper();
        private SizeMapper _sizeMapper = new SizeMapper();

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
                Brand = _brandMapper.FromEF(efEntity.Brand),
                Sizes = efEntity.Sizes.Select(s => _sizeMapper.FromEF(s))
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