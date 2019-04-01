using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Commands
{
    public class AddProductToCategoryCommandHandler : ICommandHandler<AddProductFromCategoryCommand>
    {
        public async Task Handle(ReceiveContext<AddProductFromCategoryCommand> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var command = context.Message;

            var product = await dbContext.Products.FindAsync(command.ProductUid);
            var category = await dbContext.Categories.FindAsync(command.CategoryUid);

            product.Categories.Add(category);
            category.Products.Add(product);

            await dbContext.SaveChangesAsync();
        }
    }
}