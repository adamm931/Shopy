using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Domain.Entitties;
using Shopy.Core.Extensions;
using Shopy.Core.Models;
using Shopy.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Categories.Add
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        public async Task<AddCategoryResponse> Handle(ReceiveContext<AddCategoryRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;

                var category = dbContext.Categories.Add(new Category(request.Caption));

                await dbContext.SaveChangesAsync();

                return new AddCategoryResponse(category.MapTo<CategoryReponse>());
            }
        }
    }
}