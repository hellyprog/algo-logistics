﻿using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
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
		Task<ExecutionResult> AssignShipmentsToTransportAsync(GenerateShipmentsCommand command, CancellationToken cancellationToken);
		Task<ExecutionResult> GenerateShipmentsAsync(GenerateShipmentsCommand command, CancellationToken cancellationToken);
		Task<ExecutionResult<List<Shipment>>> GetShipmentsAsync(GetShipmentsQuery query);
		Task<ExecutionResult> DeassignPackagesWithoutTransportAsync(GenerateShipmentsCommand request, CancellationToken cancellationToken);
		Task<ExecutionResult> DeleteShipmentAsync(DeleteShipmentCommand request, CancellationToken cancellationToken);
	}
}
