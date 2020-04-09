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

		public async Task<ExecutionResult> GenerateShipments(GenerateShipmentsCommand command, CancellationToken cancellationToken)
		{
			var packages = await (from package in _applicationDbContext.Packages
								  where package.Status == DeliveryStatus.NotSent
								  && package.Created.Date == DateTime.Now.AddDays(-1).Date
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

		public async Task<ExecutionResult<List<Shipment>>> GetShipments(GetShipmentsQuery query)
		{
			var shipments = await _applicationDbContext.Shipments.ToListAsync();

			return ExecutionResult<List<Shipment>>.CreateSuccessResult(shipments);
		}
	}
}
