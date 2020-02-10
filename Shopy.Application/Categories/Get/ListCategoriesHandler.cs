using Shopy.Application.Base;
using Shopy.Core.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Get
{
    public class ListCategoriesHandler : ShopyRequestHandler<ListCategoriesRequest, ListCategoriesResponse>
    {
        public ListCategoriesHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<ListCategoriesResponse> Handle(ListCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = Context.Categories
               .Include(p => p.Products)
               .Include("Products.Brand")
               .Include("Products.Sizes");

            if (request.WithProductsOnly)
            {
                categories = categories.Where(c => c.Products.Any());
            }

            var list = await categories.ToListAsync();

            return new ListCategoriesResponse(list);
        }
    }
}