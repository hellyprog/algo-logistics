using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Infrastructure.Logging
{
	public class RequestResponseLoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestResponseLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

        public async Task InvokeAsync(HttpContext context)
        {
            var requestBody = await GetRequestBodyAsync(context.Request);
            var originalBodyStream = context.Response.Body;

            Log.ForContext(LoggingConstants.TypeKey, LoggingConstants.RequestLogType)
                .ForContext("Method", context.Request.Method)
                .Information("{body}", requestBody);

            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            var response = await GerResponseBodyAsync(context.Response);

            Log.ForContext(LoggingConstants.TypeKey, LoggingConstants.ResponseLogType)
                .ForContext("statusCode", context.Response.StatusCode)
                .Information("{body}", response);

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task<string> GetRequestBodyAsync(HttpRequest request)
        {
            var body = request.Body;
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body = body;

            return bodyAsText;
        }

        private async Task<string> GerResponseBodyAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return text;
        }
    }
}
