using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Data.Entities;
using Shopy.Data;
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

            var product = dbContext.Products.Add(new ProductEF()
            {
                Uid = Guid.NewGuid(),
                Sku = GenerateSku(command, brand, size, dbContext.Products),
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

        private string GenerateSku(AddProductCommand command, BrandTypeEF brand, SizeTypeEF size, IQueryable<ProductEF> products)
        {
            //TODO: sku generator somewhere else
            var sku = $"{command.Caption.Substring(0, 3)}-"
                + $"{command.Description.Substring(0, 3)}-"
                + $"{brand.ToString().Substring(0, 3)}"
                + $"{size.Caption.Substring(0, 3)}";

            var skuCount = products.Count(p => p.Sku == sku);

            if (skuCount == 0)
            {
                return sku;
            }

            return $"sku-{skuCount++}";
        }
    }
}