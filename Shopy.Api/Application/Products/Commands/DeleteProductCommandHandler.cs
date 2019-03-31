using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Commands
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        public async Task Handle(ReceiveContext<DeleteProductCommand> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var command = context.Message;

            var toRemove = await dbContext.Products.FindAsync(command.Uid);
            dbContext.Products.Remove(toRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}