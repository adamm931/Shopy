using Shopy.Admin.ViewModels;
using Shopy.Proto;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Admin.ModelBuilder
{
    public class ProductListModelBuilder : IModelBuilder<ProductListViewModel>
    {
        private IShopyDriver _shopy;
        public ProductListModelBuilder(IShopyDriver shopy)
        {
            _shopy = shopy;
        }
        public async Task<ProductListViewModel> BuildAsync()
        {
            var products = await _shopy.ListProductsAsync();
            var model = new ProductListViewModel()
            {
                Items = products.Result.Select(p => new ProductListItemViewModel()
                {
                    Uid = p.Uid,
                    ProductId = p.ProductId,
                    Caption = p.Caption,
                    Price = p.Price
                })
            };

            return model;
        }
    }
}