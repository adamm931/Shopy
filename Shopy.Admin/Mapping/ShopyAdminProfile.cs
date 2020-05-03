using AutoMapper;
using Shopy.Admin.ViewModels;
using Shopy.Sdk.Models;
using System.Linq;

namespace Shopy.Admin.Mapping
{
    public class ShopyAdminProfile : Profile
    {
        public ShopyAdminProfile()
        {
            CreateMap<Brand, string>()
                .ConstructUsing(src => src.Id.ToString());

            CreateMap<Size, string>()
                .ConstructUsing(src => src.Id.ToString());

            CreateMap<string, ImageViewModel>()
                .ConstructUsing(src => new ImageViewModel(src));

            CreateMap<Product, ProductViewModel>()
                .ForMember(dst => dst.Image1, opts => opts.MapFrom(src => src.Image1Url))
                .ForMember(dst => dst.Image2, opts => opts.MapFrom(src => src.Image2Url))
                .ForMember(dst => dst.Image3, opts => opts.MapFrom(src => src.Image3Url))
                .ForMember(dst => dst.Sizes, opts => opts.MapFrom(src => src.Sizes))
                .ForMember(dst => dst.Brand, opts => opts.MapFrom(src => src.Brand));

            CreateMap<Product, ProductListItemViewModel>();

            CreateMap<ProductViewModel, AddEditProduct>()
                .ForMember(dst => dst.Image1, opts => opts.MapFrom(src => src.Image1.File))
                .ForMember(dst => dst.Image2, opts => opts.MapFrom(src => src.Image2.File))
                .ForMember(dst => dst.Image3, opts => opts.MapFrom(src => src.Image3.File));

            CreateMap<ProductListResponse, ProductListViewModel>()
                .ForMember(dst => dst.Items, opts => opts.MapFrom(src => src.Result))
                .AfterMap((src, dst) =>
                {
                    var list = dst.Items.ToList();
                    foreach (var item in dst.Items)
                    {
                        item.Index = list.IndexOf(item);
                    }
                });

            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, CategoryListItemViewModel>();
        }
    }
}