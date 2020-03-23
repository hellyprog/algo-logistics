using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Infrastructure.Logging
{
	public class ExceptionLoggingMiddleware
	{
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var logType = "EXCEPTION";

            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Log.Logger
                    .ForContext(LoggingConstants.TypeKey, logType)
                    .Error("Error: {error_message}\nStack trace: {stack_trace}",
                        e.Message,
                        e.StackTrace);
                throw;
            }
        }
    }
}
