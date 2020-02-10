using MediatR;
using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Edit
{
    public class EditCategorytCommandHandler : ShopyRequestHandler<EditCategoryCommand>
    {
        public EditCategorytCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await Context.Categories.ByUidAsync(request.Uid);

            category.SetName(request.Caption);

            return Unit.Value;
        }
    }
}