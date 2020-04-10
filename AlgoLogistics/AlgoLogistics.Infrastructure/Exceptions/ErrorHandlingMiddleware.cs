using AlgoLogistics.Domain.Common.Exceptions;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Infrastructure.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AlgoLogistics.Middlewares
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			var code = HttpStatusCode.InternalServerError;
			var errorMessage = ex.Message;

			if (ex.InnerException != null && ex.InnerException is AlgoLogisticsException)
			{
				errorMessage = ex.InnerException.Message;
				code = HttpStatusCode.BadRequest;
			}

			var result = JsonConvert.SerializeObject(ExecutionResult.CreateFailureResult(errorMessage, code.ToString()));
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			return context.Response.WriteAsync(result);
		}
	}
}
