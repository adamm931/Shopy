using AutoMapper;
using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;

namespace Shopy.Core.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<SizeType, SizeResponse>();

            CreateMap<BrandType, BrandResponse>();

            CreateMap<Product, ProductResponse>();
            CreateMap<Product, CategoryProductResponse>();
            CreateMap<Product, RelatedProductResponse>();
            CreateMap<Product, ProductDetailsResponse>();

            CreateMap<Category, CategoryReponse>();
            CreateMap<Category, ProductCategoryResponse>();
        }
    }
}
