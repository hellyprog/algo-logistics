using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Common.Models
{
	public class ExecutionResult
	{
		public bool Success { get; protected set; }
		public string ErrorMessage { get; protected set; }
		public string CustomExecutionCode { get; protected set; }

		public static ExecutionResult CreateSuccessResult(string customExecutionCode = null)
		{
			return new ExecutionResult
			{
				CustomExecutionCode = customExecutionCode,
				Success = true
			};
		}

		public static ExecutionResult CreateFailureResult(string errorMessage, string customExecutionCode = null)
		{
			return new ExecutionResult
			{
				CustomExecutionCode = customExecutionCode,
				ErrorMessage = errorMessage,
				Success = false
			};
		}
	}
}
