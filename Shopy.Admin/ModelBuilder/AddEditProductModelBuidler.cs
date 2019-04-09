using Shopy.Admin.ViewModels;
using Shopy.SDK.Models;
using System.Threading.Tasks;

namespace Shopy.Admin.ModelBuilder
{
    public class AddEditProductModelBuidler : IModelBuilder<AddEditProduct>
    {
        private ProductViewModel _viewModel;
        public IModelBuilder<AddEditProduct> FromViewModel(ProductViewModel productViewModel)
        {
            _viewModel = productViewModel;
            return this;
        }

        public async Task<AddEditProduct> BuildAsync()
        {
            return await Task.Run(() =>
            {
                var addProduct = new AddEditProduct()
                {
                    Uid = _viewModel.Uid,
                    Caption = _viewModel.Caption,
                    Description = _viewModel.Description,
                    Price = _viewModel.Price,
                    Brand = _viewModel.Brand,
                    Sizes = _viewModel.Sizes,
                    Image1 = _viewModel.Image1.File,
                    Image2 = _viewModel.Image2.File,
                    Image3 = _viewModel.Image3.File
                };

                return addProduct;
            });
        }
    }
}