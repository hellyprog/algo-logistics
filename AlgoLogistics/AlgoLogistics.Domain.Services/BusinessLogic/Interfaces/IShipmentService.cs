using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.BusinessLogic.Interfaces
{
	public interface IShipmentService
	{
		Task<ExecutionResult> AssignCarsToShipmentsAsync();
		Task<ExecutionResult> GenerateShipments(GenerateShipmentsCommand command, CancellationToken cancellationToken);
		Task<ExecutionResult<List<Shipment>>> GetShipments(GetShipmentsQuery query);
	}
}
