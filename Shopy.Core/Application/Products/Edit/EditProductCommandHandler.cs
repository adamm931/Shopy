using Mediator.Net.Context;
using Mediator.Net.Contracts;
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
            var dbContext = ShopyContext.Current;
            var command = context.Message;

            var product = await dbContext.Products.FindAsync(command.Uid);

            var brand = await dbContext.BrandTypes
                .FirstOrDefaultAsync(b => b.BrandTypeEId == command.Brand);

            var size = await dbContext.SizeTypes
                .FirstOrDefaultAsync(s => s.SizeTypeEID == command.Size);

            product.Price = command.Price;
            product.Caption = command.Caption;
            product.Size = size;
            product.Brand = brand;
            product.Description = command.Description;

            await dbContext.SaveChangesAsync();
        }
    }
}