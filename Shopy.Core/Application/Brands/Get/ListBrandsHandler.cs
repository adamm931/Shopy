using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Extensions;
using Shopy.Core.Models;
using Shopy.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Brands.Get
{
    public class ListBrandsHandler : IRequestHandler<ListBrandsRequest, ListBrandsResponse>
    {
        public async Task<ListBrandsResponse> Handle(ReceiveContext<ListBrandsRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;
                var brands = await dbContext.BrandTypes.ToListAsync();

                return new ListBrandsResponse(brands.MapTo<IEnumerable<BrandResponse>>());
            }
        }
    }
}