using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.BusinessLogic
{
	public class ShipmentService : IShipmentService
	{
		private readonly IApplicationDbContext _applicationDbContext;
		private readonly ICityNetworkProvider _cityNetworkProvider;

		public ShipmentService(
			IApplicationDbContext applicationDbContext,
			ICityNetworkProvider cityNetworkProvider)
		{
			_applicationDbContext = applicationDbContext;
			_cityNetworkProvider = cityNetworkProvider;
		}

		public Task<ExecutionResult> AssignCarsToShipmentsAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<ExecutionResult> DeleteShipmentAsync(DeleteShipmentCommand request, CancellationToken cancellationToken)
		{
			var shipmentToDelete = await _applicationDbContext.Shipments.FirstOrDefaultAsync(s => s.ShipmentId == request.ShipmentId);
			_applicationDbContext.Shipments.Remove(shipmentToDelete);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Cannot remove shipment");
		}

		public async Task<ExecutionResult> GenerateShipmentsAsync(GenerateShipmentsCommand command, CancellationToken cancellationToken)
		{
			var packages = await (from package in _applicationDbContext.Packages
								  where package.Status == PackageDeliveryStatus.NotSent
								  && package.Created > command.FromDate
								  && package.Created < command.ToDate
								  select package).ToListAsync();

			var shipmentList = new List<Shipment>();

			var groupedPackagesByFromCity = from package in packages
											group package by package.DeliveryDetails.FromCity into g
											select new { g.Key, Grouped = g };

			foreach (var groupedPackageByFromCity in groupedPackagesByFromCity)
			{
				var groupedPackagesByToCity = from package in groupedPackageByFromCity.Grouped
											  group package by package.DeliveryDetails.ToCity into g
											  select new { g.Key, Grouped = g };

				foreach (var package in groupedPackagesByToCity)
				{
					var shipment = await Shipment.CreateAsync(package.Grouped.ToList(), _cityNetworkProvider);
					shipmentList.Add(shipment);
				}
			}

			_applicationDbContext.Shipments.AddRange(shipmentList);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Shipment generation failed");
		}

		public async Task<ExecutionResult<List<Shipment>>> GetShipmentsAsync(GetShipmentsQuery query)
		{
			var shipments = await _applicationDbContext.Shipments.ToListAsync();

			return ExecutionResult<List<Shipment>>.CreateSuccessResult(shipments);
		}
	}
}
