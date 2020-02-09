using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Extensions;
using Shopy.Core.Models;
using Shopy.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Categories.Add
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, GetCategoryResponse>
    {
        public async Task<GetCategoryResponse> Handle(ReceiveContext<GetCategoryRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;

                var category = await dbContext.Categories.FindAsync(request.Uid);

                if (category == null)
                {
                    return null;
                }

                return new GetCategoryResponse(category.MapTo<CategoryReponse>());
            }
        }
    }
}