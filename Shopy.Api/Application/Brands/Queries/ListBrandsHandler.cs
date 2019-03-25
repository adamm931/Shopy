using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListBrandsHandler : IRequestHandler<ListBrandsRequest, ListBrandsResponse>
    {
        public async Task<ListBrandsResponse> Handle(ReceiveContext<ListBrandsRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = new ShopContext();
            var request = context.Message;

            var result = await dbContext.BrandTypes
                .Select(b => new Brand()
                {
                    Uid = b.BrandTypeEId,
                    Caption = b.Caption
                })
                .ToListAsync();

            return new ListBrandsResponse(result);
        }
    }
}