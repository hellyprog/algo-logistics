using AlgoLogistics.Domain.Services.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AlgoLogistics.Filters
{
	public class ValidatorActionFilter : IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (!filterContext.ModelState.IsValid)
			{
				var errors = string.Join(';', filterContext.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
				var executionResult = ExecutionResult.CreateFailureResult(errors);
				filterContext.Result = new BadRequestObjectResult(executionResult);
			}
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
		}
	}
}
