using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Exceptions;
using Shopy.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.RemoveFromCategory
{
    public class RemoveProductFromCategoryCommandHandler : ICommandHandler<RemoveProductFromCategoryCommand>
    {
        public async Task Handle(ReceiveContext<RemoveProductFromCategoryCommand> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var command = context.Message;

                var product = await dbContext.Products
                    .Include(p => p.Categories)
                    .FirstOrDefaultAsync(p => p.Uid == command.ProductUid);

                if (product == null)
                {
                    throw new ProductNotFoundException(command.ProductUid);
                }

                //var category = await dbContext.Categories
                //    .Include(p => p.Products)
                //    .FirstOrDefaultAsync(c => c.Uid == command.CategoryUid);

                //if (category == null)
                //{
                //    throw new CategoryNotFoundException(command.CategoryUid);
                //}

                product.RemoveCategory(command.CategoryUid);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}