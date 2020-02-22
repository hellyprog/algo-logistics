using AlgoLogistics.Application.Commands;
using AlgoLogistics.Application.Common.Interfaces;
using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Domain.Enums;
using AlgoLogistics.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

		public GenerateShipmentsCommandHandler(
			IApplicationDbContext applicationDbContext, 
			IShipmentService shipmentService)
		{
			_applicationDbContext = applicationDbContext;
			_shipmentService = shipmentService;
		}

		public async Task<ExecutionResult> Handle(GenerateShipmentsCommand request, CancellationToken cancellationToken)
		{
			var packages = await (from package in _applicationDbContext.Packages
								   where package.Status == DeliveryStatus.NotSent
								   && package.Created.Date == DateTime.Now.AddDays(-1).Date
								   select package).ToListAsync();
											
			var shipments = await _shipmentService.GenerateShipments(packages);

			_applicationDbContext.Shipments.AddRange(shipments);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
                : ExecutionResult.CreateFailureResult("Shipment generation failed");
		}
	}
}
