using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;
using System;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class GenerateShipmentsCommand : IRequest<ExecutionResult>
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}
