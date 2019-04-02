using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Data;
using System.Data.Entity;
using System.Linq;
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

                var product = await dbContext.Products.FindAsync(command.Uid);

                var brand = await dbContext.BrandTypes
                    .SingleAsync(b => b.BrandTypeEId == command.Brand);

                var sizes = await dbContext.SizeTypes
                    .Where(s => command.Sizes.Any(cs => cs.EId == s.SizeTypeEID))
                    .ToListAsync();

                product.Price = command.Price;
                product.Caption = command.Caption;
                product.Sizes = sizes;
                product.Brand = brand;
                product.Description = command.Description;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}