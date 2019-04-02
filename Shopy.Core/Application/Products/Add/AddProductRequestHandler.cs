using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Core.Mappers;
using Shopy.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Add
{
    public class AddProductRequestHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        public async Task<AddProductResponse> Handle(ReceiveContext<AddProductRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var command = context.Message;

            var brand = dbContext.BrandTypes
                .FirstOrDefault(b => b.BrandTypeEId == command.Brand);

            var size = dbContext.SizeTypes
                .FirstOrDefault(s => s.SizeTypeEID == command.Size);

            var uid = Guid.NewGuid();
            var productEf = dbContext.Products.Add(new ProductEF()
            {
                Uid = uid,
                Caption = command.Caption,
                Description = command.Description,
                Price = command.Price,
                Brand = brand,
                Size = size
            });

            await dbContext.SaveChangesAsync();

            productEf = await dbContext.Products.FindAsync(uid);

            var productMapper = new ProductMapper();

            return new AddProductResponse(productMapper.FromEF(productEf));
        }
    }
}