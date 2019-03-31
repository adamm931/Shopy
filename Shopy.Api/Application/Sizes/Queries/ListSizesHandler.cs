using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Mappers;
using Shopy.Data;
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
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var mapper = new SizeMapper();
            var sizes = await dbContext.SizeTypes.ToListAsync();
            var projection = sizes.Select(s => mapper.FromEF(s));

            return new ListSizesResponse(projection);

        }
    }
}