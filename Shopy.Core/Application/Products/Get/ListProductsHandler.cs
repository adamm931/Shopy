using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Core.Mappers;
using Shopy.Core.Models;
using Shopy.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Get
{
    public class ListProductsHandler : IRequestHandler<ListProductsRequest, ListProductsResponse>
    {
        public async Task<ListProductsResponse> Handle(ReceiveContext<ListProductsRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;

                var products = dbContext.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Sizes)
                    .Include(p => p.Categories);

                return await FilterProducts(products, request.Filter);
            }
        }

        private async Task<ListProductsResponse> FilterProducts(IQueryable<ProductEF> products, ProductFilter productFilter)
        {
            //price
            if (productFilter.MinPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price >= productFilter.MinPrice.Value);
            }

            if (productFilter.MaxPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price <= productFilter.MaxPrice.Value);
            }

            //size
            if (!string.IsNullOrWhiteSpace(productFilter.Sizes))
            {
                var filterSizes = productFilter.Sizes.Split(',');

                products = products
                    .Where(p => filterSizes.Any(fs => p.Sizes.Any(s => s.SizeTypeEID == fs)));
            }

            //brand
            if (!string.IsNullOrWhiteSpace(productFilter.Brands))
            {
                var brands = productFilter.Brands.Split(',');

                products = products
                    .Where(p => brands.Any(b => p.Brand.BrandTypeEId == b));
            }

            //category
            if (productFilter.CategoryUid.HasValue)
            {
                products = products
                    .Where(p => p.Categories.Any(c => c.Uid == productFilter.CategoryUid.Value));
            }

            var totalRecords = await products.CountAsync();

            //paging
            if (productFilter.PageSize.HasValue && productFilter.PageIndex.HasValue)
            {
                var pageSize = productFilter.PageSize.Value;
                var pageIndex = productFilter.PageIndex.Value;

                products = products
                    .OrderBy(p => p.ProductId)
                    .Skip(pageIndex * pageSize)
                    .Take((pageIndex + 1) * pageSize);
            }

            var filteredProducts = await products.ToListAsync();
            var productMapper = new ProductMapper(new CategoryMapper());
            var projection = filteredProducts.Select(r => productMapper.FromEF(r));
            var response = new ListProductsResponse(projection, totalRecords);

            return response;
        }
    }
}