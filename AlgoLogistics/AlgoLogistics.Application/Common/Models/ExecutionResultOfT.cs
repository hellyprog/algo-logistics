using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Common.Models
{
	public class ExecutionResult<T> : ExecutionResult
	{
		public T Data { get; private set; }

		public static ExecutionResult<T> CreateSuccessResult(T data, string customExecutionCode = null)
		{
			return new ExecutionResult<T>
			{
				Data = data,
				Success = true
			};
		}

		public new static ExecutionResult<T> CreateFailureResult(string errorMessage, string customExecutionCode = null)
		{
			return new ExecutionResult<T>
			{
				CustomExecutionCode = customExecutionCode,
				ErrorMessage = errorMessage,
				Success = false
			};
		}
	}
}
