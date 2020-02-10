using MediatR;
using Shopy.Core.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Pipelines
{
    public class LoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public LoggingPipeline(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.Info($"Begin of request: {typeof(TRequest).Name}");

            var response = await next();

            _logger.Info($"End of request: {typeof(TRequest).Name}");

            return response;
        }
    }
}
