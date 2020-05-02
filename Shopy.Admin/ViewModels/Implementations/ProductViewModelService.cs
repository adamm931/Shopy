using AutoMapper;
using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels.Interfaces;
using Shopy.Sdk;
using Shopy.Sdk.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Admin.ViewModels.Implementations
{
    public class ProductViewModelService : IProductViewModelService
    {
        private readonly IShopyDriver _shopy;
        private readonly IMapper _mapper;
        private readonly ISelectListUtils _selectListUtils;

        public ProductViewModelService(
            IShopyDriver shopy,
            IMapper mapper,
            ISelectListUtils selectListUtils)
        {
            _shopy = shopy;
            _mapper = mapper;
            _selectListUtils = selectListUtils;
        }

        public async Task<ProductViewModel> GetEmptyProduct()
        {
            var viewModel = new ProductViewModel
            {
                Image1 = ImageViewModel.Empty,
                Image2 = ImageViewModel.Empty,
                Image3 = ImageViewModel.Empty,
            };

            await viewModel.PopulateSizesAndBrands(_selectListUtils);

            return viewModel;
        }

        public async Task<ProductViewModel> PopulateProduct(ProductViewModel product)
        {
            await product.PopulateSizesAndBrands(_selectListUtils);

            return product;
        }

        public async Task<ProductViewModel> GetProduct(Guid uid)
        {
            var product = await _shopy.GetProductAsync(uid);
            var viewModel = _mapper.Map<ProductViewModel>(product);
            await viewModel.PopulateSizesAndBrands(_selectListUtils);

            return viewModel;
        }

        public async Task<ProductListViewModel> GetProductList()
        {
            var products = await _shopy.ListProductsAsync();
            var viewModel = _mapper.Map<ProductListViewModel>(products);

            return viewModel;
        }

        public async Task AddProduct(ProductViewModel product)
        {
            var productToAdd = _mapper.Map<AddEditProduct>(product);

            await _shopy.AddProductAsync(productToAdd);
        }

        public async Task EditProduct(ProductViewModel product)
        {
            var productToAdd = _mapper.Map<AddEditProduct>(product);

            await _shopy.EditProductAsync(productToAdd);
        }

        public async Task<ChangeProductCategoriesViewModel> GetProductCategoryChange(Guid uid)
        {
            var product = await _shopy.GetProductAsync(uid);

            var model = new ChangeProductCategoriesViewModel
            {
                ProductUid = uid,
                Name = product.Name
            };

            return model;
        }

        public async Task<ProductCategoriesViewModel> GetProductCategories(Guid uid)
        {
            var categories = await _shopy.ListCategoriesAsync();

            var model = new ProductCategoriesViewModel()
            {
                AvailableCategories = categories
                    .Where(c => !c.Products.Any(p => p.Uid == uid))
                    .Select(c => new CategoryListItemViewModel
                    {
                        Uid = c.Uid,
                        Name = c.Name
                    }),

                AssignedCategories = categories
                    .Where(c => c.Products.Any(p => p.Uid == uid))
                    .Select(c => new CategoryListItemViewModel
                    {
                        Uid = c.Uid,
                        Name = c.Name
                    })
            };

            return model;
        }
    }
}