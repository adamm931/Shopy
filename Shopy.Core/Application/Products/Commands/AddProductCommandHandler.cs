using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Commands
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        public async Task Handle(ReceiveContext<AddProductCommand> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var command = context.Message;

            var brand = dbContext.BrandTypes
                .FirstOrDefault(b => b.BrandTypeEId == command.Brand);

            var size = dbContext.SizeTypes
                .FirstOrDefault(s => s.SizeTypeEID == command.Size);

            var product = dbContext.Products.Add(new ProductEF()
            {
                Uid = Guid.NewGuid(),
                Caption = command.Caption,
                Description = command.Description,
                Price = command.Price,
                Brand = brand,
                Size = size
            });

            var images = command.Images.Select(c => new ImageEF()
            {
                Uid = new Guid(),
                Name = c.Name
            })
            .ToList();

            product.Images = images;

            await dbContext.SaveChangesAsync();
        }
    }
}