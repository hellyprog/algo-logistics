using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class RegisterTransportDepartureCommand : IRequest<ExecutionResult>
	{
		public string TransportNo { get; set; }
	}
}
