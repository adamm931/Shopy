using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Models;
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
                .ToListAsync();

            var product = products.FirstOrDefault(p => p.Uid == request.Uid);

            var allCategories = await dbContext.Categories.ToListAsync();
            var productCategories = product.Categories.ToList();

            var availableCategories = allCategories.Where(
                c => !productCategories.Any(pc => pc.Uid == c.Uid));

            var assignedCategories = allCategories.Where(
                c => productCategories.Any(pc => pc.Uid == c.Uid));

            var availableSizes = await dbContext.SizeTypes
                .Where(s => s.Products.Any(p => p.Uid == product.Uid))
                .Select(s => new Size()
                {
                    Uid = s.SizeTypeEID,
                    Caption = s.Caption
                })
                .ToListAsync();

            var relatedProducts = products
                .Where(p => productCategories.Any(pc => p.Categories.Any(c => c.Uid == pc.Uid)))
                .Select(p => new ProductLight()
                {
                    Uid = p.Uid,
                    Caption = p.Caption,
                    Price = p.Price
                });

            return new GetProductDetailsResponse()
            {
                Uid = product.Uid,
                ProductID = product.ProductID,
                Brand = product.Brand.Caption,
                Size = product.Size.Caption,
                Caption = product.Caption,
                Description = product.Description,
                Price = product.Price,
                AvailableSizes = availableSizes,
                RelatedProducts = relatedProducts,
                AssignedCategories = assignedCategories.Select(c => new CategoryLight()
                {
                    Uid = c.Uid,
                    CategoryId = c.CategoryID,
                    Caption = c.Caption
                }),
                AvailableCategories = availableCategories.Select(c => new CategoryLight()
                {
                    Uid = c.Uid,
                    CategoryId = c.CategoryID,
                    Caption = c.Caption
                })
            };

        }
    }
}