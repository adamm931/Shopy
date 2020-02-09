using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Extensions;
using Shopy.Core.Models;
using Shopy.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Sizes.Get
{
    public class ListSizesHandler : IRequestHandler<ListSizesRequest, ListSizesResponse>
    {
        public async Task<ListSizesResponse> Handle(ReceiveContext<ListSizesRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;

                var sizes = await dbContext.SizeTypes.ToListAsync();

                var projection = sizes
                    .OrderBy(s => s.Id)
                    .MapTo<IEnumerable<SizeResponse>>();

                return new ListSizesResponse(projection);
            }
        }
    }
}