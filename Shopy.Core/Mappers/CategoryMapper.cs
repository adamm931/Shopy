using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System.Linq;

namespace Shopy.Core.Mappers
{
    public class CategoryMapper : IMapper<Category, CategoryEF>
    {
        private ProductMapper _productMapper;

        public CategoryMapper(ProductMapper productMapper = null)
        {
            _productMapper = productMapper;
        }

        public Category FromEF(CategoryEF efEntity)
        {
            var category = new Category()
            {
                Uid = efEntity.Uid,
                Caption = efEntity.Caption,
                CategoryId = efEntity.CategoryId
            };

            if (_productMapper != null)
            {
                category.Products = efEntity.Products.Select(p => _productMapper.FromEF(p)).ToList();
            }

            return category;
        }

        public CategoryEF ToEF<TSoure>(Category model)
        {
            return new CategoryEF()
            {
                Uid = model.Uid,
                Caption = model.Caption,
                CategoryId = model.CategoryId
            };
        }
    }
}