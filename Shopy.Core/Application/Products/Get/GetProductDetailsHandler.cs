using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Common;
using Shopy.Core.Extensions;
using Shopy.Core.Models;
using Shopy.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductDetailsHandler : IRequestHandler<GetProductDetailsRequest, GetProductDetailsResponse>
    {
        public async Task<GetProductDetailsResponse> Handle(ReceiveContext<GetProductDetailsRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;

                var products = await dbContext.Products
                    .Include(p => p.Categories)
                    .Include(p => p.BrandType)
                    .Include(p => p.Sizes)
                    .ToListAsync();

                var product = products.FirstOrDefault(p => p.Uid == request.Uid);

                if (product == null)
                {
                    return null;
                }

                var relatedProducts = products
                   .Where(p => product.Categories
                        .Any(pc => p.Categories
                            .Any(c => c.Uid == pc.Uid)))
                   .Where(p => p.Uid != request.Uid)
                   .Randomize()
                   .Take(4);

                var productDetails = new ProductDetailsResponse
                {
                    Product = product.MapTo<ProductReponse>(),
                    RelatedProducts = relatedProducts.MapTo<IEnumerable<ProductReponse>>()
                };

                return new GetProductDetailsResponse(productDetails);
            }
        }
    }
}