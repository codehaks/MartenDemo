using MediatR;
using Microsoft.Extensions.Logging;
using MyApp.Application.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application.Common
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<FindQuery.Request, FindQuery.Response>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }



        async Task<FindQuery.Response> IPipelineBehavior<FindQuery.Request, FindQuery.Response>.Handle(FindQuery.Request request
            , CancellationToken cancellationToken, RequestHandlerDelegate<FindQuery.Response> next)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");

            return response;
        }
    }
}
