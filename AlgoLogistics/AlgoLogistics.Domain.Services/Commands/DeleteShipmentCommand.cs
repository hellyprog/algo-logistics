using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;

namespace AlgoLogistics.Domain.Services
{
	public class DeleteShipmentCommand : IRequest<ExecutionResult>
	{
		public int ShipmentId { get; set; }
	}
}