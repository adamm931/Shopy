using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Domain.Entitties.Interfaces;
using Shopy.Core.Exceptions;
using Shopy.Data;
using System.Data.Entity;
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

                var category = await dbContext.Categories
                    .FirstOrDefaultAsync(cat => cat.HasUid(command.Uid));

                if (category == null)
                {
                    throw new CategoryNotFoundException(command.Uid);
                }

                category.SetName(command.Caption);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}