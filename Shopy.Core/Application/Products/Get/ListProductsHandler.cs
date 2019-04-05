using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Core.Mappers;
using Shopy.Core.Models;
using Shopy.Data;
using System.Collections.Generic;
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

                var filteredProducts = await FilterProducts(products, request.Filter);
                var productMapper = new ProductMapper(new CategoryMapper());
                var result = filteredProducts.Select(r => productMapper.FromEF(r));

                return new ListProductsResponse(result);
            }
        }

        private async Task<List<ProductEF>> FilterProducts(IQueryable<ProductEF> products, ProductFilter productFilter)
        {
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

            return await products.ToListAsync();
        }
    }
}