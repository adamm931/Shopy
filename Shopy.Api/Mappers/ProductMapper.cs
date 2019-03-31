using Shopy.Api.Data.Entities;
using Shopy.Api.Models;
using System;
using System.Linq;

namespace Shopy.Api.Mappers
{
    public class ProductMapper : IMapper<Product, ProductEF>
    {
        private BrandMapper _brandMapper;
        private SizeMapper _sizeMapper;
        private ImageMapper _imageMapper;

        public ProductMapper()
        {
            _brandMapper = new BrandMapper();
            _sizeMapper = new SizeMapper();
            _imageMapper = new ImageMapper();
        }

        public Product FromEF(ProductEF efEntity)
        {
            return new Product()
            {
                Sku = efEntity.Sku,
                Uid = efEntity.Uid,
                Caption = efEntity.Caption,
                Description = efEntity.Description,
                Price = efEntity.Price,
                Brand = _brandMapper.FromEF(efEntity.Brand),
                Size = _sizeMapper.FromEF(efEntity.Size),
                Images = efEntity.Images.Select(i => _imageMapper.FromEF(i)).ToList()
            };

        }

        public ProductEF ToEF<TSoure>(Product model)
        {
            throw new NotImplementedException();
        }
    }
}