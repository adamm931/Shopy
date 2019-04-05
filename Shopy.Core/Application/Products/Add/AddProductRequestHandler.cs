using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities;
using Shopy.Core.Mappers;
using Shopy.Data;
using System;
using System.Data.Entity;
using System.Linq;
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

                var brand = await dbContext.BrandTypes
                    .SingleAsync(b => b.BrandTypeEId == command.Brand);

                var sizes = await dbContext.SizeTypes
                    .Where(s => command.Sizes.Any(cs => cs == s.SizeTypeEID))
                    .ToListAsync();

                var uid = Guid.NewGuid();

                var productEf = dbContext.Products.Add(new ProductEF()
                {
                    Uid = uid,
                    Caption = command.Caption,
                    Description = command.Description,
                    Price = command.Price,
                    Brand = brand,
                    Sizes = sizes
                });

                foreach (var size in sizes)
                {
                    size.Products.Add(productEf);
                }

                await dbContext.SaveChangesAsync();

                productEf = await dbContext.Products.FindAsync(uid);

                var productMapper = new ProductMapper();

                return new AddProductResponse(productMapper.FromEF(productEf));
            }
        }
    }
}