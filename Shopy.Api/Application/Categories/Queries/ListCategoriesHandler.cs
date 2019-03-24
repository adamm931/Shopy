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
            var request = context.Message;

            var result = dbContext.Categories
                .Include(p => p.Products)
                .Include("Products.Brand")
                .Include("Products.Size");

            if (request.WithProductsOnly)
            {
                result = result.Where(c => c.Products.Any());
            }

            var projection = await result.Select(r => new Category()
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
            }).ToListAsync();

            return new ListCategoriesResponse(projection);

        }
    }
}