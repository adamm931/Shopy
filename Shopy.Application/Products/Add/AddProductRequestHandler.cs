using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using Shopy.Core.Domain.Entitties;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Add
{
    public class AddProductRequestHandler : ShopyRequestHandler<AddProductRequest, AddProductResponse>
    {
        public AddProductRequestHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product(
                Guid.NewGuid(),
                request.Caption,
                request.Description,
                request.Price.Value);

            var brand = await Context.BrandTypes.ByEnumIdAsync(request.Brand);

            product.SetBrand(brand);

            foreach (var size in request.Sizes)
            {
                var sizeType = await Context.SizeTypes.ByEnumIdAsync(size);
                product.AddSize(sizeType);
            }

            return new AddProductResponse(product);
        }
    }
}