﻿using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Exceptions;
using Shopy.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Commands
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        public async Task Handle(ReceiveContext<DeleteProductCommand> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var command = context.Message;

                var toRemove = await dbContext.Products.FindAsync(command.Uid);

                if (toRemove == null)
                {
                    throw new ProductNotFoundException(command.Uid);
                }

                dbContext.Products.Remove(toRemove);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}