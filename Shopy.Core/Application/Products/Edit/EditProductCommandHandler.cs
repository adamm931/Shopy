using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Exceptions;
using Shopy.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Edit
{
    public class UpdateProductCommandHandler : ICommandHandler<EditProductCommand>
    {
        public async Task Handle(ReceiveContext<EditProductCommand> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var command = context.Message;

                var product = await dbContext.Products
                    .Include(p => p.Sizes)
                    .Include(p => p.BrandType)
                    .FirstOrDefaultAsync(p => p.Uid == command.Uid);

                if (product == null)
                {
                    throw new ProductNotFoundException(command.Uid);
                }

                product.Update(command.Caption, command.Description, command.Price, null, null/*command.Brand, command.Sizes*/);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}