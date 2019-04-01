using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System;
using System.Linq;

namespace Shopy.Core.Mappers
{
    public class ProductMapper : IMapper<Product, ProductEF>
    {
        //private BrandMapper _brandMapper;
        //private SizeMapper _sizeMapper;
        private ImageMapper _imageMapper;

        public ProductMapper()
        {
            // _brandMapper = new BrandMapper();
            // _sizeMapper = new SizeMapper();
            _imageMapper = new ImageMapper();
        }

        public Product FromEF(ProductEF efEntity)
        {
            return new Product()
            {
                Uid = efEntity.Uid,
                Caption = efEntity.Caption,
                Description = efEntity.Description,
                Price = efEntity.Price,
                Brand = efEntity.BrandEId,
                Size = efEntity.SizeEId,
                Images = efEntity.Images.Select(i => _imageMapper.FromEF(i)).ToList()
            };

        }

        public ProductEF ToEF<TSoure>(Product model)
        {
            throw new NotImplementedException();
        }
    }
}