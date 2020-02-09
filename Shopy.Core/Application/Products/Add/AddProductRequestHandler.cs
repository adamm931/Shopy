using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Domain.Entitties;
using Shopy.Core.Extensions;
using Shopy.Core.Models;
using Shopy.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Add
{
    public class AddProductRequestHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        public async Task<AddProductResponse> Handle(ReceiveContext<AddProductRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var command = context.Message;

                var product = new Product(
                    Guid.NewGuid(),
                    command.Caption,
                    command.Description,
                    command.Price.Value);

                var brand = await dbContext.BrandTypes.FindAsync(command.Brand);

                product.SetBrand(brand);

                foreach (var size in command.Sizes)
                {
                    var sizeType = await dbContext.SizeTypes.FindAsync(size);
                    product.AddSize(sizeType);
                }

                await dbContext.SaveChangesAsync();

                return new AddProductResponse(product.MapTo<ProductReponse>());
            }
        }
    }
}