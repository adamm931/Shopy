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

            var projection = result.Select(r => new CategoryDTO()
            {
                Uid = r.Uid,
                Caption = r.Caption,
                Products = r.Products.Select(p => new CategoryProductDTO()
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