using MediatR;
using Shopy.Application.Base;
using Shopy.Core.Data;
using Shopy.Core.Data.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.Commands
{
    public class DeleteProductCommandHandler : ShopyRequestHandler<DeleteProductCommand>
    {
        public DeleteProductCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await Context.Products.ByUidAsync(request.Uid);

            Context.Products.Remove(product);

            return Unit.Value;
        }
    }
}