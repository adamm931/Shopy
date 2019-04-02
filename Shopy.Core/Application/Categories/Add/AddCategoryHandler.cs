using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Core.Mappers;
using Shopy.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Categories.Add
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        public async Task<AddCategoryResponse> Handle(ReceiveContext<AddCategoryRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var category = dbContext.Categories.Add(new CategoryEF()
            {
                Uid = Guid.NewGuid(),
                Caption = request.Caption
            });

            await dbContext.SaveChangesAsync();

            var categoryMapper = new CategoryMapper();

            return new AddCategoryResponse(categoryMapper.FromEF(category));
        }
    }
}