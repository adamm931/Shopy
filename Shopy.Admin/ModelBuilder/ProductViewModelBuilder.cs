using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels;
using Shopy.Sdk;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Admin.ModelBuilder
{
    public class ProductModelBuilder : IModelBuilder<ProductViewModel>
    {
        private ISelectListUtils _selectListUtils;
        private IShopyDriver _shopy;

        private Guid _uid;

        public ProductModelBuilder(
            ISelectListUtils selectListUtils,
            IShopyDriver shopy)
        {
            _selectListUtils = selectListUtils;
            _shopy = shopy;
        }

        public IModelBuilder<ProductViewModel> WithUid(Guid uid)
        {
            if (uid == Guid.Empty)
            {
                throw new ArgumentException("Product uid is empty");
            }
            _uid = uid;
            return this;
        }

        public async Task<ProductViewModel> BuildAsync()
        {
            var product = await _shopy.GetProductAsync(_uid);

            if (product == null)
            {
                throw new Exception($"Product not found with id: {_uid}");
            }

            var model = new ProductViewModel()
            {
                Uid = _uid,
                Caption = product.Caption,
                Description = product.Description,
                Price = product.Price,
                Brand = product.Brand.EId,
                Sizes = product.Sizes.Select(s => s.EId),
                SelectedSizesML = await _selectListUtils.GetSizesMSL(),
                BrandsSelectList = await _selectListUtils.GetBrandsSL(),
                Image1 = new ImageViewModel(product.Image1.Url),
                Image2 = new ImageViewModel(product.Image2.Url),
                Image3 = new ImageViewModel(product.Image3.Url),
            };

            return model;
        }
    }
}