using MediatR;
using Shopy.Core.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Pipelines
{
    public class SaveChangesPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IShopyContext _context;

        public SaveChangesPipeline(IShopyContext context)
        {
            _context = context;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            await _context.Save();

            return response;
        }
    }
}
