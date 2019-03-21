using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Application.DTOS;
using Shopy.Api.Data;
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
            var dbContext = ShopContext.Current;

            var result = await dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .Include(p => p.Categories)
                .ToListAsync();

            var projection = result.Select(r => new ProductDTO()
            {
                Caption = r.Caption,
                Description = r.Description,
                ProductID = r.ProductID,
                BrandType = r.Brand.Caption,
                Price = r.Price,
                SizeType = r.Size.Caption,
                Uid = r.Uid,
                Categories = r.Categories.Select(c => new ProductCategoryDTO()
                {
                    Caption = c.Caption
                }).ToList()
            });

            return new ListProductsResponse(projection);
        }
    }
}