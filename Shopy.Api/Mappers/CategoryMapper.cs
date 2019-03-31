﻿using Shopy.Api.Data.Entities;
using Shopy.Api.Models;
using System.Linq;

namespace Shopy.Api.Mappers
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