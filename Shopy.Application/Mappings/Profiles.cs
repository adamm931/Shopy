using AutoMapper;
using Shopy.Application.Models;
using Shopy.Core.Domain.Entitties;

namespace Shopy.Application.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<SizeType, SizeResponse>();
            CreateMap<BrandType, BrandResponse>();

            CreateMap<Product, ProductResponse>()
                .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.BrandType));

            CreateMap<Product, CategoryProductResponse>();
            CreateMap<Product, RelatedProductResponse>();
            CreateMap<Product, ProductDetailsResponse>();

            CreateMap<Category, CategoryReponse>();
            CreateMap<Category, ProductCategoryResponse>();
        }
    }
}
