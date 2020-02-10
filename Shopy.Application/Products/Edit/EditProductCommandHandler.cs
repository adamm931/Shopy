using MediatR;
using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Edit
{
    public class UpdateProductCommandHandler : ShopyRequestHandler<EditProductCommand>
    {
        public UpdateProductCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                       .Include(p => p.Sizes)
                       .Include(p => p.BrandType)
                       .ByUidAsync(request.Uid);

            var brand = await Context.BrandTypes.ByEnumIdAsync(request.Brand);
            var sizes = await Context.SizeTypes.ByEnumIdsAsync(request.Sizes);

            product.Update(request.Caption, request.Description, request.Price, brand, sizes);

            return Unit.Value;
        }
    }
}