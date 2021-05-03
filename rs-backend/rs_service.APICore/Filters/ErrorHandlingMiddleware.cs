using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace rs_service.APICore.Filters
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ILogger logger = new LoggerFactory().CreateLogger<Program>();
            logger.LogError("RS SERVICE: error: {0}, inner: {1}, code: {2}, data: {3}, source: {4}, targetSite: {5}, stackTrace: {6}",
                              ex.Message, ex.InnerException, ex.HResult, ex.Data, ex.Source, ex.TargetSite, ex.StackTrace);


            // smaller version of error is sent to the client
            var result = JsonConvert.SerializeObject(new { error = ex.Message, inner = ex.InnerException, code = ex.HResult });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.HResult; //(int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
