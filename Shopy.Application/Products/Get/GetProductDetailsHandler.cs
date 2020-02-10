using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using Shopy.Core.Domain.Entitties;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Get
{
    public class GetProductDetailsHandler : ShopyRequestHandler<GetProductDetailsRequest, GetProductDetailsResponse>
    {
        public GetProductDetailsHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<GetProductDetailsResponse> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                    .Include(p => p.Categories)
                    .Include($"{nameof(Product.Categories)}.{nameof(Category.Products)}")
                    .Include($"{nameof(Product.Categories)}.{nameof(Category.Products)}.{nameof(Product.Sizes)}")
                    .Include(p => p.BrandType)
                    .Include(p => p.Sizes)
                    .ByUidAsync(request.Uid);

            return new GetProductDetailsResponse(product);
        }
    }
}