﻿using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Data.Entities;
using Shopy.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Commands
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        public async Task Handle(ReceiveContext<UpdateProductCommand> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var command = context.Message;

            var product = await dbContext.Products.FindAsync(command.Uid);

            var brand = await dbContext.BrandTypes
                .FirstOrDefaultAsync(b => b.Caption.Equals(command.BrandType, StringComparison.OrdinalIgnoreCase));

            var size = await dbContext.SizeTypes
                .FirstOrDefaultAsync(b => b.Caption.Equals(command.SizeType, StringComparison.OrdinalIgnoreCase));

            var newImages = command.Images
                .Where(i => product.Images.Any(c => c.Uid == i.Uid))
                .Select(c => new ImageEF()
                {
                    Uid = Guid.NewGuid(),
                    Name = c.Name
                });

            foreach (var productImage in product.Images)
            {
                productImage.Name = command.Images
                    .First(ci => ci.Uid == productImage.Uid)
                    .Name;
            }

            product.Images.AddRange(newImages);

            product.Price = command.Price;
            product.Caption = command.Caption;
            product.Size = size;
            product.Brand = brand;
            product.Description = command.Description;
            product.Images = new List<ImageEF>();

            await dbContext.SaveChangesAsync();
        }
    }
}