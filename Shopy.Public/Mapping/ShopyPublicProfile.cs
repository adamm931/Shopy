using AutoMapper;
using Shopy.Public.ViewModels;
using Shopy.Sdk.Models;

namespace Shopy.Public.Mapping
{
    public class ShopyPublicProfile : Profile
    {
        public ShopyPublicProfile()
        {
            CreateMap<ProductDetails, ProductDetailsViewModel>();

            CreateMap<Brand, FilterViewModel>()
                .ForMember(dst => dst.Value, opts => opts.MapFrom(src => ((int)src.Id).ToString()));

            CreateMap<Size, FilterViewModel>()
                .ForMember(dst => dst.Value, opts => opts.MapFrom(src => ((int)src.Id).ToString()));

            CreateMap<CategoryLookup, FilterViewModel>()
                .ForMember(dst => dst.Value, opts => opts.MapFrom(src => src.Uid.ToString()));

            CreateMap<Product, ProductViewModel>()
                .ForMember(dst => dst.MainImageUrl, opts => opts.MapFrom(src => src.Image1Url));

            CreateMap<Size, string>()
                .ConstructUsing(src => src.Name);

            CreateMap<Product, RelatedProductViewModel>()
                .ForMember(dst => dst.MainImageUrl, opts => opts.MapFrom(src => src.Image1Url));
        }
    }
}