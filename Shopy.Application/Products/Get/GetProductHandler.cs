using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Get
{
    public class GetProductHandler : ShopyRequestHandler<GetProductRequest, GetProductResponse>
    {
        public GetProductHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await Context.Products
                    .Include(p => p.Sizes)
                    .Include(p => p.BrandType)
                    .ByUidAsync(request.Uid);

            return new GetProductResponse(product);
        }
    }
}