using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.BusinessLogic
{
	public class CarShipmentService : ShipmentService
	{
		public CarShipmentService(
			IApplicationDbContext applicationDbContext, 
			ICityNetworkProvider cityNetworkProvider) : base(applicationDbContext, cityNetworkProvider)
		{
		}

		public override Task<ExecutionResult> AssignShipmentsToTransportAsync(GenerateShipmentsCommand command)
		{
			var currentShipments = (from shipment in _applicationDbContext.Shipments
								   where shipment.ShipmentStatus == Enums.ShipmentStatus.Shipping
								   && shipment.Created > command.FromDate
								   && shipment.Created < command.ToDate
								   select shipment).ToListAsync();



			return default;
		}
	}
}
