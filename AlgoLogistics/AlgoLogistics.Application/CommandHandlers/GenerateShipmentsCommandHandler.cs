﻿using AlgoLogistics.Application.Commands;
using AlgoLogistics.Application.Common.Interfaces;
using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.CommandHandlers
{
	public class GenerateShipmentsCommandHandler : IRequestHandler<GenerateShipmentsCommand, ExecutionResult>
	{
		private readonly IApplicationDbContext _applicationDbContext;
		private readonly IShipmentService _shipmentService;
		private readonly IPackagesDataQuery _packagesDataQuery;

		public GenerateShipmentsCommandHandler(
			IApplicationDbContext applicationDbContext, 
			IShipmentService shipmentService,
			IPackagesDataQuery packagesDataQuery)
		{
			_applicationDbContext = applicationDbContext;
			_shipmentService = shipmentService;
			_packagesDataQuery = packagesDataQuery;
		}

		public async Task<ExecutionResult> Handle(GenerateShipmentsCommand request, CancellationToken cancellationToken)
		{
			var shipments = await _shipmentService.GenerateShipments(_packagesDataQuery);

			_applicationDbContext.Shipments.AddRange(shipments);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
                : ExecutionResult.CreateFailureResult("Shipment generation failed");
		}
	}
}