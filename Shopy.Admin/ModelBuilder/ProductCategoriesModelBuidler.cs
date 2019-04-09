using Shopy.Admin.ViewModels;
using Shopy.SDK;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Admin.ModelBuilder
{
    public class ProductCategoriesModelBuidler : IModelBuilder<ProductCategoriesViewModel>
    {
        private IShopyDriver _shopy;
        private Guid _productUid;

        public ProductCategoriesModelBuidler(IShopyDriver shopy)
        {
            _shopy = shopy;
        }

        public IModelBuilder<ProductCategoriesViewModel> ForProduct(Guid productUid)
        {
            _productUid = productUid;
            return this;
        }

        public async Task<ProductCategoriesViewModel> BuildAsync()
        {
            var categories = await _shopy.ListCategoriesAsync();

            var model = new ProductCategoriesViewModel()
            {
                AvailableCategories = categories
                    .Where(c => !c.Products.Any(p => p.Uid == _productUid))
                    .Select(c => new CategoryListItemViewModel()
                    {
                        Uid = c.Uid,
                        CategoryId = c.CategoryId,
                        Caption = c.Caption
                    }),

                AssignedCategories = categories
                    .Where(c => c.Products.Any(p => p.Uid == _productUid))
                    .Select(c => new CategoryListItemViewModel()
                    {
                        Uid = c.Uid,
                        CategoryId = c.CategoryId,
                        Caption = c.Caption
                    })
            };

            return model;
        }
    }
}