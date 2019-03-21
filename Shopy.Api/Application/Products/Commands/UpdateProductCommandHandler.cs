using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Data;
using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Commands
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        public async Task Handle(ReceiveContext<UpdateProductCommand> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopContext.Current;
            var command = context.Message;

            var product = await dbContext.Products.FindAsync(command.Uid);

            var brand = await dbContext.BrandTypes
                .FirstOrDefaultAsync(b => b.Caption.Equals(command.BrandType, StringComparison.OrdinalIgnoreCase));

            var size = await dbContext.SizeTypes
                .FirstOrDefaultAsync(b => b.Caption.Equals(command.SizeType, StringComparison.OrdinalIgnoreCase));

            product.Price = command.Price;
            product.Caption = command.Caption;
            product.Size = size;
            product.Brand = brand;
            product.Description = command.Description;

            await dbContext.SaveChangesAsync();
        }
    }
}