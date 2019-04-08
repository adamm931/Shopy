using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels;
using System.Threading.Tasks;

namespace Shopy.Admin.ModelBuilder
{
    public class DefaultProductModelBuilder : IModelBuilder<ProductViewModel>
    {
        private ISelectListUtils _selectListUtils;
        private ProductViewModel _inner;

        public DefaultProductModelBuilder(ISelectListUtils selectListUtils)
        {
            _selectListUtils = selectListUtils;
        }

        public IModelBuilder<ProductViewModel> WithInner(ProductViewModel inner)
        {
            _inner = inner;
            return this;
        }

        public async Task<ProductViewModel> BuildAsync()
        {
            var model = _inner ?? new ProductViewModel();
            model.BrandsSelectList = await _selectListUtils.GetBrandsSL();
            model.SelectedSizesML = await _selectListUtils.GetSizesMSL();

            if (_inner == null)
            {
                model.Image1 =
                    model.Image2 =
                    model.Image3 = ImageViewModel.Empty;
            }

            else
            {
                model.Image1 = new ImageViewModel(model.Image1.Url);
                model.Image2 = new ImageViewModel(model.Image2.Url);
                model.Image3 = new ImageViewModel(model.Image3.Url);
            }

            return model;
        }
    }
}