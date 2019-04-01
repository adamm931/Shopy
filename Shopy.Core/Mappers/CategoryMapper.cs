using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System.Linq;

namespace Shopy.Core.Mappers
{
    public class CategoryMapper : IMapper<Category, CategoryEF>
    {
        private ProductMapper _productMapper;

        public CategoryMapper()
        {
            _productMapper = new ProductMapper();
        }

        public Category FromEF(CategoryEF efEntity)
        {
            return new Category()
            {
                Uid = efEntity.Uid,
                Caption = efEntity.Caption,
                CategoryId = efEntity.CategoryId,
                Products = efEntity.Products.Select(p => _productMapper.FromEF(p)).ToList()
            };
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