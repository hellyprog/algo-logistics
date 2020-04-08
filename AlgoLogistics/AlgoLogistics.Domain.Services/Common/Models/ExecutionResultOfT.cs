namespace AlgoLogistics.Domain.Services.Common.Models
{
	public class ExecutionResult<T> : ExecutionResult
	{
		public T Data { get; private set; }

		public static ExecutionResult<T> CreateSuccessResult(T data, string customExecutionCode = null)
		{
			return new ExecutionResult<T>
			{
				Data = data,
				Success = true,
				CustomExecutionCode = customExecutionCode
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
