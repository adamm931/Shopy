using Shopy.Application.Base;
using Shopy.Application.Products.Get;
using Shopy.Core.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.GetCategories
{
    public class GetProductCategoriesHandler : ShopyRequestHandler<GetProductCategoriesRequest, GetProductCategoriesResponse>
    {
        public GetProductCategoriesHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<GetProductCategoriesResponse> Handle(GetProductCategoriesRequest request, CancellationToken cancellationToken)
        {
            var productByUid = await Context.Products
                .Include(product => product.Categories)
                .SingleAsync(product => product.Uid == request.Uid);

            return new GetProductCategoriesResponse(productByUid.Categories.ToList());
        }
    }
}
