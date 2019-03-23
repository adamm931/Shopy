using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListCategoriesHandler : IRequestHandler<ListCategoriesRequest, ListCategoriesResponse>
    {
        public async Task<ListCategoriesResponse> Handle(ReceiveContext<ListCategoriesRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = new ShopContext();

            var result = await dbContext.Categories
                .Include(p => p.Products)
                .Include("Products.Brand")
                .Include("Products.Size")
                .ToListAsync();

            var projection = result.Select(r => new Category()
            {
                Uid = r.Uid,
                CategoryId = r.CategoryID,
                Caption = r.Caption,
                Products = r.Products.Select(p => new ProductLight()
                {
                    Brand = p.Brand.Caption,
                    Uid = p.Uid,
                    Size = p.Size.Caption
                }).ToList()
            });

            return new ListCategoriesResponse(projection);

        }
    }
}