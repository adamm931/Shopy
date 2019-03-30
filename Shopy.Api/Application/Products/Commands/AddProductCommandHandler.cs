using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Common;
using Shopy.Api.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Commands
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        public async Task Handle(ReceiveContext<AddProductCommand> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var command = context.Message;

            var brand = dbContext.BrandTypes
                .FirstOrDefault(b => b.Caption.Equals(command.BrandType, StringComparison.OrdinalIgnoreCase));

            var size = dbContext.SizeTypes
                .FirstOrDefault(b => b.Caption.Equals(command.SizeType, StringComparison.OrdinalIgnoreCase));

            dbContext.Products.Add(new ProductEF()
            {
                Uid = Guid.NewGuid(),
                ProductID = dbContext.GetValueFromSequence(Constants.ProductsSeq),
                Caption = command.Caption,
                Description = command.Description,
                Price = command.Price,
                Brand = brand,
                Size = size
            });

            await dbContext.SaveChangesAsync();
        }
    }
}