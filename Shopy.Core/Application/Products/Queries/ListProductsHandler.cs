using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Core.Mappers;
using Shopy.Core.Models;
using Shopy.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Queries
{
    public class ListProductsHandler : IRequestHandler<ListProductsRequest, ListProductsResponse>
    {
        public Task<ListProductsResponse> Handle(ReceiveContext<ListProductsRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var products = dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .Include(p => p.Categories)
                .Include(p => p.Images)
                .AsNoTracking()
                .AsEnumerable();

            products = FilterProducts(products, request.Filter);

            var productMapper = new ProductMapper();
            var result = products.Select(r => productMapper.FromEF(r));

            return Task.FromResult(new ListProductsResponse(result));
        }

        private IEnumerable<ProductEF> FilterProducts(IEnumerable<ProductEF> products, ProductFilter productFilter)
        {
            //paging
            if (productFilter.PageSize.HasValue && productFilter.PageIndex.HasValue)
            {
                var pageSize = productFilter.PageSize.Value;
                var pageIndex = productFilter.PageIndex.Value;

                products = products
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
                var sizes = productFilter.Sizes.Split(',');

                products = products
                    .Where(p => sizes.Any(s => p.Size.Caption.Equals(s, StringComparison.OrdinalIgnoreCase)));
            }

            //brand
            if (!string.IsNullOrWhiteSpace(productFilter.Brands))
            {
                var brands = productFilter.Brands.Split(',');

                products = products
                    .Where(p => brands.Any(b => p.Brand.Caption.Equals(b, StringComparison.OrdinalIgnoreCase)));
            }

            return products;
        }
    }
}