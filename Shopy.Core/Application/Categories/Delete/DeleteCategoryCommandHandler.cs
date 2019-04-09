using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Exceptions;
using Shopy.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Categories.Delete
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        public async Task Handle(ReceiveContext<DeleteCategoryCommand> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var command = context.Message;

                var toRemove = await dbContext.Categories.FindAsync(command.Uid);

                if (toRemove == null)
                {
                    throw new CategoryNotFoundException(command.Uid);
                }

                dbContext.Categories.Remove(toRemove);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
