using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Mappers;
using Shopy.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Brands.Get
{
    public class ListBrandsHandler : IRequestHandler<ListBrandsRequest, ListBrandsResponse>
    {
        public async Task<ListBrandsResponse> Handle(ReceiveContext<ListBrandsRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var brandMapper = new BrandMapper();
            var brands = await dbContext.BrandTypes.ToListAsync();
            var projection = brands.Select(b => brandMapper.FromEF(b));

            return new ListBrandsResponse(projection);
        }
    }
}