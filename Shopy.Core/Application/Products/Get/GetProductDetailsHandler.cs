using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Mappers;
using Shopy.Core.Models;
using Shopy.Data;
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

                var product = products.Single(p => p.Uid == request.Uid);
                var productMapper = new ProductMapper();
                var relatedProducts = products
                    .Where(p => product.Categories.Any(pc => p.Categories.Any(c => c.Uid == pc.Uid)))
                    .Select(p => productMapper.FromEF(p));

                var productDetails = new ProductDetails()
                {
                    Uid = product.Uid,
                    ProductId = product.ProductId,
                    Caption = product.Caption,
                    Description = product.Description,
                    Price = product.Price,
                    Brand = product.BrandEId,
                    Sizes = product.Sizes.Select(s => s.SizeTypeEID),
                    RelatedProducts = relatedProducts,
                };

                return new GetProductDetailsResponse(productDetails);
            }
        }
    }
}