using Shopy.Application.Base;
using Shopy.Core.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Sizes.Get
{
    public class ListSizesHandler : ShopyRequestHandler<ListSizesRequest, ListSizesResponse>
    {
        public ListSizesHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<ListSizesResponse> Handle(ListSizesRequest request, CancellationToken cancellationToken)
        {
            var sizes = await Context.SizeTypes.OrderBy(s => s.Id).ToListAsync();

            return new ListSizesResponse(sizes);
        }
    }
}