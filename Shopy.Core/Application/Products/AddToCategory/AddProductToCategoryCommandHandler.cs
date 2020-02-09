using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Exceptions;
using Shopy.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.AddToCategory
{
    public class AddProductToCategoryCommandHandler : ICommandHandler<AddProductFromCategoryCommand>
    {
        public async Task Handle(ReceiveContext<AddProductFromCategoryCommand> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var command = context.Message;

                var product = await dbContext.Products.FindAsync(command.ProductUid);

                if (product == null)
                {
                    throw new ProductNotFoundException(command.ProductUid);
                }

                var category = await dbContext.Categories.FindAsync(command.CategoryUid);

                if (category == null)
                {
                    throw new CategoryNotFoundException(command.CategoryUid);
                }

                product.AddCategory(category);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}