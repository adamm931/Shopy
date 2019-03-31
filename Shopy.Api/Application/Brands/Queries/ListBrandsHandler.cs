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
    public class ListBrandsHandler : IRequestHandler<ListBrandsRequest, ListBrandsResponse>
    {
        public async Task<ListBrandsResponse> Handle(ReceiveContext<ListBrandsRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var brandMapper = new BrandMapper();
            var result = await dbContext.BrandTypes
                .Select(b => brandMapper.FromEF(b))
                .ToListAsync();

            return new ListBrandsResponse(result);
        }
    }
}