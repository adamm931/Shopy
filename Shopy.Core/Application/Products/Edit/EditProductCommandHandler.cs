using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Data;
using System.Collections.Generic;
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

                var product = await dbContext.Products
                    .Include(p => p.Sizes)
                    .Include(p => p.Brand)
                    .SingleAsync(p => p.Uid == command.Uid);

                var sizes = product.Sizes;

                if (command.Sizes != null && command.Sizes.Any())
                {
                    sizes = await EditSizesAsync(dbContext, product, command.Sizes);
                }

                var brand = product.Brand;

                if (command.Brand != null)
                {
                    brand = await dbContext.BrandTypes
                        .SingleAsync(b => b.BrandTypeEId == command.Brand);
                }

                product.Price = command.Price ?? product.Price;
                product.Caption = command.Caption ?? product.Caption;
                product.Sizes = sizes;
                product.Brand = brand;
                product.Description = command.Description ?? product.Description;

                await dbContext.SaveChangesAsync();
            }
        }

        private async Task<List<SizeTypeEF>> EditSizesAsync(ShopyContext dbContext, ProductEF product, IEnumerable<string> commandSizesEIds)
        {
            var sizeForProductSet = await dbContext.SizeTypes
                   .Where(s => commandSizesEIds.Any(cs => cs == s.SizeTypeEID))
                   .ToListAsync();

            var removedSizes = product.Sizes.Except(sizeForProductSet);
            var newSizes = sizeForProductSet.Except(product.Sizes);

            foreach (var size in newSizes)
            {
                size.Products.Add(product);
            }

            foreach (var size in removedSizes)
            {
                size.Products.Remove(product);
            }

            return sizeForProductSet;
        }
    }
}