using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListSizesHandler : IRequestHandler<ListSizesRequest, ListSizesResponse>
    {
        public async Task<ListSizesResponse> Handle(ReceiveContext<ListSizesRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = new ShopContext();
            var request = context.Message;

            var result = await dbContext.SizeTypes
                .Select(s => new Size()
                {
                    Uid = s.SizeTypeEID,
                    Caption = s.Caption
                })
                .ToListAsync();

            return new ListSizesResponse(result);

        }
    }
}