using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Models;
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

            var projection = result.Select(r => new Product()
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
            });

            return new ListProductsResponse(projection);
        }
    }
}