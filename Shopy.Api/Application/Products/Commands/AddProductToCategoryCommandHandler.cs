using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Commands
{
    public class AddProductToCategoryCommandHandler : ICommandHandler<AddProductFromCategoryCommand>
    {
        public async Task Handle(ReceiveContext<AddProductFromCategoryCommand> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopContext.Current;
            var command = context.Message;

            var product = await dbContext.Products.FindAsync(command.ProductUid);
            var category = await dbContext.Categories.FindAsync(command.CategoryUid);

            product.Categories.Add(category);
            category.Products.Add(product);

            await dbContext.SaveChangesAsync();
        }
    }
}