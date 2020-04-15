using Shopy.Application.Base;
using Shopy.Core.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Add
{
    public class LookupCategoriesHandler : ShopyRequestHandler<LookupCategoriesRequest, LookupCategoriesResponse>
    {
        public LookupCategoriesHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<LookupCategoriesResponse> Handle(LookupCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await Context.Categories.ToListAsync();

            return new LookupCategoriesResponse(categories);
        }
    }
}