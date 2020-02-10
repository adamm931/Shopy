using MediatR;
using Shopy.Core.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Base
{
    public abstract class ShopyRequestHandler<TRequest, TReponse> : IRequestHandler<TRequest, TReponse>
        where TRequest : IRequest<TReponse>
    {
        protected IShopyContext Context { get; }

        public ShopyRequestHandler(IShopyContext context)
        {
            Context = context;
        }

        public abstract Task<TReponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class ShopyRequestHandler<TRequest> : ShopyRequestHandler<TRequest, Unit>
         where TRequest : IRequest<Unit>
    {
        public ShopyRequestHandler(IShopyContext context) : base(context)
        {
        }
    }
}
