using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Extensions;
using Shopy.Core.Models;
using Shopy.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        public async Task<GetProductResponse> Handle(ReceiveContext<GetProductRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;
                var product = await dbContext.Products
                    .Include(p => p.Sizes)
                    .Include(p => p.BrandType)
                    .FirstOrDefaultAsync(p => p.Uid == request.Uid);

                if (product == null)
                {
                    return null;
                }

                return new GetProductResponse(product.MapTo<ProductReponse>());
            }
        }
    }
}