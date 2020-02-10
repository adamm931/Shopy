using MediatR;
using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.RemoveFromCategory
{
    public class RemoveProductFromCategoryCommandHandler : ShopyRequestHandler<RemoveProductFromCategoryCommand>
    {
        public RemoveProductFromCategoryCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(RemoveProductFromCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                .Include(product => product.Categories)
                .ByUidAsync(request.ProductUid);

            var category = await Context.Categories
                .ByUidAsync(request.CategoryUid);

            product.RemoveCategory(request.CategoryUid);

            return Unit.Value;
        }
    }
}