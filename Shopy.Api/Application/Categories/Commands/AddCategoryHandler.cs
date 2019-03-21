using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Data;
using Shopy.Api.Data.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Categories.Commands
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        public async Task<AddCategoryResponse> Handle(ReceiveContext<AddCategoryRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopContext.Current;
            var request = context.Message;

            var category = dbContext.Categories.Add(new Category()
            {
                Uid = Guid.NewGuid(),
                Caption = request.Caption
            });

            await dbContext.SaveChangesAsync();

            return new AddCategoryResponse()
            {
                Uid = category.Uid,
                Caption = category.Caption,
                CategoryID = category.CategoryID
            };
        }
    }
}