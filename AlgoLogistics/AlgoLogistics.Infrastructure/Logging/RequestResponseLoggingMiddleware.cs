using Microsoft.AspNetCore.Http;
using Serilog;
using System;
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
			context.Request.EnableBuffering();
			var requestBody = await GetRequestBodyAsync(context.Request);
			context.Request.Body.Position = 0;
			var originalBodyStream = context.Response.Body;

			Log.ForContext(LoggingConstants.TypeKey, LoggingConstants.RequestLogType)
				.ForContext("Method", context.Request.Method)
				.Information("{body}", requestBody);

			try
			{
				using var responseBody = new MemoryStream();
				context.Response.Body = responseBody;

				await _next(context);

				var response = await GerResponseBodyAsync(context.Response);

				Log.ForContext(LoggingConstants.TypeKey, LoggingConstants.ResponseLogType)
					.ForContext("statusCode", context.Response.StatusCode)
					.Information("{body}", response);

				responseBody.Position = 0;
				await responseBody.CopyToAsync(originalBodyStream);
			}
			finally
			{
				context.Response.Body = originalBodyStream;
			}
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
