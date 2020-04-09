using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Executors.Interfaces
{
	public interface IShipmentLogicExecutor
	{
		Task<ExecutionResult<List<Shipment>>> GetShipmentsAsync();
		Task<ExecutionResult> GenerateShipmentsAsync();
	}
}
