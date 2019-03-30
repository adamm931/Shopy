using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Entities;
using Shopy.Api.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListProductsHandler : IRequestHandler<ListProductsRequest, ListProductsResponse>
    {
        public async Task<ListProductsResponse> Handle(ReceiveContext<ListProductsRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var result = dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .Include(p => p.Categories);

            result = FilterProducts(result, request.Filter);

            var projection = await result.Select(r => new Product()
            {
                Caption = r.Caption,
                Description = r.Description,
                ProductID = r.ProductID,
                Brand = r.Brand.Caption,
                Price = r.Price,
                Size = r.Size.Caption,
                Uid = r.Uid,
                Categories = r.Categories.Select(c => new CategoryLight()
                {
                    Uid = c.Uid,
                    CategoryId = c.CategoryID,
                    Caption = c.Caption
                }).ToList()
            }).ToListAsync();

            return new ListProductsResponse(projection);
        }

        private IQueryable<ProductEF> FilterProducts(IQueryable<ProductEF> products, ProductFilter productFilter)
        {
            //paging
            if (productFilter.PageSize.HasValue && productFilter.PageIndex.HasValue)
            {
                var pageSize = productFilter.PageSize.Value;
                var pageIndex = productFilter.PageIndex.Value;

                products = products
                    .OrderBy(p => p.Caption)
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