using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Api.Application.DTOS;
using Shopy.Api.Data;
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
            var dbContext = ShopContext.Current;
            var request = context.Message;

            var product = await dbContext.Products
                .Include(p => p.Categories)
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(p => p.Uid == request.Uid);

            var allCategories = await dbContext.Categories.ToListAsync();
            var productCategories = product.Categories.ToList();

            var availableCategories = allCategories.Where(
                c => !productCategories.Any(pc => pc.Uid == c.Uid));

            var assignedCategories = allCategories.Where(
                c => productCategories.Any(pc => pc.Uid == c.Uid));

            return new GetProductDetailsResponse()
            {
                Uid = product.Uid,
                BrandType = product.Brand.Caption,
                SizeType = product.Size.Caption,
                Caption = product.Caption,
                Description = product.Description,
                Price = product.Price,
                AssignedCategories = assignedCategories.Select(c => new ProductCategoryDTO()
                {
                    Uid = c.Uid,
                    Caption = c.Caption
                }),
                AvailableCategories = availableCategories.Select(c => new ProductCategoryDTO()
                {
                    Uid = c.Uid,
                    Caption = c.Caption
                })
            };

        }
    }
}