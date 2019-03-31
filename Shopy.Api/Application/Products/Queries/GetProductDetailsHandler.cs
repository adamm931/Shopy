using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Mappers;
using Shopy.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Api.Application.Products.Queries
{
    public class GetProductDetailsHandler : IRequestHandler<GetProductDetailsRequest, GetProductDetailsResponse>
    {
        public async Task<GetProductDetailsResponse> Handle(ReceiveContext<GetProductDetailsRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var products = await dbContext.Products
                .Include(p => p.Categories)
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .Include(p => p.Images)
                .ToListAsync();

            var product = products.Single(p => p.Sku == request.Sku);
            var productCategories = product.Categories.ToList();
            var productMapper = new ProductMapper();
            var relatedProducts = products
                .Where(p => productCategories.Any(pc => p.Categories.Any(c => c.Uid == pc.Uid)))
                .Select(p => productMapper.FromEF(p));

            return new GetProductDetailsResponse()
            {
                Product = productMapper.FromEF(product),
                RelatedProducts = relatedProducts
            };
        }
    }
}