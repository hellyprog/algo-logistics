using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class GenerateShipmentsCommand : IRequest<ExecutionResult>
	{
	}
}
