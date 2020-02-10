using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Add
{
    public class GetCategoryHandler : ShopyRequestHandler<GetCategoryRequest, GetCategoryResponse>
    {
        public GetCategoryHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<GetCategoryResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await Context.Categories.ByUidAsync(request.Uid);

            return new GetCategoryResponse(category);
        }
    }
}