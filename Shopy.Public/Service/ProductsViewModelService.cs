using AutoMapper;
using Shopy.Public.ViewModels;
using Shopy.Sdk;
using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Public.Service
{
    public class ProductsViewModelService : IProductsViewModelService
    {
        private readonly IShopyDriver _shopy;
        private readonly IMapper _mapper;

        public ProductsViewModelService(IShopyDriver shopy, IMapper mapper)
        {
            _shopy = shopy;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<ProductViewModel>> FilterProducts(ProductFilter filter)
        {
            var products = await _shopy.ListProducts(filter);
            var items = _mapper.Map<IEnumerable<ProductViewModel>>(products.Result);
            var viewModel = new PagedListViewModel<ProductViewModel>(items, products.TotalRecords);

            return viewModel;
        }

        public async Task<ProductFiltersViewModel> GetFilters()
        {
            // TODO: create api method to get all filter setup
            var brands = await _shopy.ListBrands();
            var sizes = await _shopy.ListSizes();
            var categoriesLookup = await _shopy.LookupCategories();

            var viewModel = new ProductFiltersViewModel
            {
                BrandFilters = _mapper.Map<IEnumerable<FilterViewModel>>(brands),
                SizeFilters = _mapper.Map<IEnumerable<FilterViewModel>>(sizes),
                CategoryFilters = _mapper.Map<IEnumerable<FilterViewModel>>(categoriesLookup),
            };

            return viewModel;
        }

        public async Task<ProductDetailsViewModel> GetProductDetails(Guid uid)
        {
            var productDetails = await _shopy.GetProductDetails(uid);
            var viewModel = _mapper.Map<ProductDetailsViewModel>(productDetails);

            return viewModel;
        }
    }
}