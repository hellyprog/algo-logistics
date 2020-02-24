using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Interfaces
{
	public interface IShipmentService
	{
		Task<ExecutionResult<List<Shipment>>> GetShipmentsAsync();
		Task<ExecutionResult> GenerateShipmentsAsync();
	}
}
