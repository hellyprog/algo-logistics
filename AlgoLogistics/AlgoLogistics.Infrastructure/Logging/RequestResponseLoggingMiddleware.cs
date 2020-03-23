using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
			var logType = "REQUEST";

			await _next(context);
		}
	}
}
