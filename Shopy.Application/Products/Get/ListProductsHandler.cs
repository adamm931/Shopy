﻿using Shopy.Application.Base;
using Shopy.Application.Models;
using Shopy.Core.Data;
using Shopy.Core.Domain.Entitties;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Get
{
    public class ListProductsHandler : ShopyRequestHandler<ListProductsRequest, ListProductsResponse>
    {
        public ListProductsHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<ListProductsResponse> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            var products = Context.Products
                   .Include(p => p.BrandType)
                   .Include(p => p.Sizes)
                   .Include(p => p.Categories);

            return await FilterProducts(products, request.Filter);
        }

        private async Task<ListProductsResponse> FilterProducts(IQueryable<Product> products, ProductFilter productFilter)
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
                var sizeTypeIds = SizeType.ParseIds(productFilter.Sizes);

                products = products
                    .Where(p => sizeTypeIds.Any(fs => p.Sizes.Any(s => s.Id == fs)));
            }

            //brand
            if (!string.IsNullOrWhiteSpace(productFilter.Brands))
            {
                var brandTypeIds = BrandType.ParseIds(productFilter.Brands);

                products = products
                    .Where(p => brandTypeIds.Any(b => p.BrandTypeId == b));
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
                    .OrderBy(p => p.Id)
                    .Skip(pageIndex * pageSize)
                    .Take((pageIndex + 1) * pageSize);
            }

            return new ListProductsResponse(products, totalRecords);
        }
    }
}