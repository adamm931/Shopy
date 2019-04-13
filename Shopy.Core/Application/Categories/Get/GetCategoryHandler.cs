using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Core.Exceptions;
using Shopy.Core.Mappers;
using Shopy.Data;
using System;
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

                if(category == null)
                {
                    return null;
                }

                var categoryMapper = new CategoryMapper();

                return new GetCategoryResponse(categoryMapper.FromEF(category));
            }
        }
    }
}