using MediatR;
using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Delete
{
    public class DeleteCategoryCommandHandler : ShopyRequestHandler<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await Context.Categories.ByUidAsync(request.Uid);
            Context.Categories.Remove(category);

            return Unit.Value;
        }
    }
}
