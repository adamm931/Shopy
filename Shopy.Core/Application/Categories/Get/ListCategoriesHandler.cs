using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Mappers;
using Shopy.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Categories.Get
{
    public class ListCategoriesHandler : IRequestHandler<ListCategoriesRequest, ListCategoriesResponse>
    {
        public async Task<ListCategoriesResponse> Handle(ReceiveContext<ListCategoriesRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var categories = dbContext.Categories
                .Include(p => p.Products)
                .Include("Products.Brand")
                .Include("Products.Size");

            if (request.WithProductsOnly)
            {
                categories = categories.Where(c => c.Products.Any());
            }

            var categoryList = await categories.ToListAsync();
            var mapper = new CategoryMapper();
            var projection = categoryList.Select(c => mapper.FromEF(c));
            return new ListCategoriesResponse(projection);
        }
    }
}