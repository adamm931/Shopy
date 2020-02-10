using Shopy.Application.Base;
using Shopy.Core.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Brands.Get
{
    public class ListBrandsHandler : ShopyRequestHandler<ListBrandsRequest, ListBrandsResponse>
    {
        public ListBrandsHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<ListBrandsResponse> Handle(ListBrandsRequest request, CancellationToken cancellationToken)
        {
            var brands = await Context.BrandTypes.ToListAsync();

            return new ListBrandsResponse(brands);
        }
    }
}