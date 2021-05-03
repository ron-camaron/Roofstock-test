using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace rs_service.Application.Infrastructure
{
    // This RequestLogger class uses MediatR to intercept every single Request and log
    // the information of it
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            //TODO: Add information about user

            _logger.LogInformation("RS SERVICE Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}
