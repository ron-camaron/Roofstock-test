using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace rs_service.Application.Infrastructure
{
    // This RequestPerformanceBehaviour class uses MediatR to intercept every single Request 
    // and log as a warning, every petition that takes more than 500 milliseconds
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();

            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                // TODO: Add User Details

                _logger.LogWarning("RS SERVICE Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}
