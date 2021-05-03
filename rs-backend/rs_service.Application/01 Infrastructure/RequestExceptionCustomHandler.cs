using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace rs_service.Application.Infrastructure
{
    public class RequestExceptionCustomHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException> where TException : Exception
    {
        private readonly ILogger<RequestExceptionCustomHandler<TRequest, TResponse, TException>> _logger;

        public RequestExceptionCustomHandler(ILogger<RequestExceptionCustomHandler<TRequest, TResponse, TException>> logger)
        {
            _logger = logger;
        }

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogError(exception, "RS SERVICE Unhandled Exception while executing the following request {@Request}", request);
            });
        }
    }
}
