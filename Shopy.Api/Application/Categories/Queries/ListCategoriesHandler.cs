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
    public class ListCategoriesHandler : IRequestHandler<ListCategoriesRequest, ListCategoriesResponse>
    {
        public async Task<ListCategoriesResponse> Handle(ReceiveContext<ListCategoriesRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var categories = await dbContext.Categories
                .Include(p => p.Products)
                .Include("Products.Brand")
                .Include("Products.Size")
                .Where(c => c.Products.Any())
                .ToListAsync();

            var mapper = new CategoryMapper();
            var projection = categories.Select(c => mapper.FromEF(c));
            return new ListCategoriesResponse(projection);
        }
    }
}