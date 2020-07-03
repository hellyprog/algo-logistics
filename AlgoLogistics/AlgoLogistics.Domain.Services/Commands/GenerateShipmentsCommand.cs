using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;
using System;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class GenerateShipmentsCommand : IRequest<ExecutionResult>
	{
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
	}
}
