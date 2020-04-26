using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Add
{
    public class AddCategoryHandler : ShopyRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        public AddCategoryHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<AddCategoryResponse> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = Context.Categories.Add(new Category(request.Name));

            await Context.Save();

            return new AddCategoryResponse(category);
        }
    }
}