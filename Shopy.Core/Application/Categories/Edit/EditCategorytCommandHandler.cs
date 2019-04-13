using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Application.Categories.Edit;
using Shopy.Core.Data.Entities;
using Shopy.Core.Exceptions;
using Shopy.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Categories.Edit
{
    public class EditCategorytCommandHandler : ICommandHandler<EditCategoryCommand>
    {
        public async Task Handle(ReceiveContext<EditCategoryCommand> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var command = context.Message;
                var category = await dbContext.Categories.FindAsync(command.Uid);

                if(category == null)
                {
                    throw new CategoryNotFoundException(command.Uid);
                }

                category.Caption = command.Caption ?? category.Caption;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}