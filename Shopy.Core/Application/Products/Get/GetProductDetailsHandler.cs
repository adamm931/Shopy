using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Mappers;
using Shopy.Core.Models;
using Shopy.Data;
using System;
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
                    .Include(p => p.Brand)
                    .Include(p => p.Sizes)
                    .ToListAsync();

                var product = products.FirstOrDefault(p => p.Uid == request.Uid);

                if (product == null)
                {
                    return null;
                }

                var productMapper = new ProductMapper();
                var productMapperWithCategories = new ProductMapper(new CategoryMapper());

                var relatedProducts = products
                   .Where(p => product.Categories
                        .Any(pc => p.Categories
                            .Any(c => c.Uid == pc.Uid)))
                   .Where(p => p.Uid != request.Uid)
                   .Select(p => productMapper.FromEF(p))

                   //randomize the related products in case that 
                   //and usually will be more than 4

                   .OrderBy(o => Guid.NewGuid())
                   .Take(4);

                var productDetails = new ProductDetails()
                {
                    Product = productMapperWithCategories.FromEF(product),
                    RelatedProducts = relatedProducts
                };

                return new GetProductDetailsResponse(productDetails);
            }
        }
    }
}