using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Data;
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

                var product = await dbContext.Products.FindAsync(command.ProductUid);
                var category = await dbContext.Categories.FindAsync(command.CategoryUid);

                product.Categories.Remove(category);
                category.Products.Remove(product);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}