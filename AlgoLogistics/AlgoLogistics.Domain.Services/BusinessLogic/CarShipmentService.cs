using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AlgoLogistics.Domain.Enums;
using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AlgoLogistics.Domain.Services.BusinessLogic
{
	public class CarShipmentService : ShipmentService
	{
		public CarShipmentService(
			IApplicationDbContext applicationDbContext, 
			ICityNetworkProvider cityNetworkProvider) : base(applicationDbContext, cityNetworkProvider)
		{
		}

		public override async Task<ExecutionResult> AssignShipmentsToTransportAsync(GenerateShipmentsCommand command, CancellationToken cancellationToken)
		{
			var currentShipments = await (from shipment in _applicationDbContext.Shipments
										   where shipment.ShipmentStatus == ShipmentStatus.PackagesGrouped
										   && shipment.Created >= command.FromDate
										   && shipment.Created <= command.ToDate
										   select shipment)
										   .Include(x => x.Packages)
										   .ThenInclude(x => x.PackageCategory)
										   .ToListAsync();

			var cars = await _applicationDbContext.Transports
					.Where(t => t.TransportType == TransportType.Car)
					.ToListAsync();

			foreach (var shipment in currentShipments)
			{
				var shipmentStartCity = shipment.Route.StartCity;
				var shipmentPackages = shipment.Packages.OrderBy(x => x.Created).ThenBy(x => x.PackageCategory).ToList();
				var availableCars = cars.Where(c => c.CurrentCity == shipmentStartCity && !c.Packages.Any()).ToList();
				var queue = new Queue<Transport>(availableCars);
				var carToFill = queue.Any() ? queue.Dequeue() : default;

				if (carToFill != null)
				{
					var carVolume = carToFill.PhysicalParameters.Height * carToFill.PhysicalParameters.Length * carToFill.PhysicalParameters.Width;

					foreach (var package in shipmentPackages)
					{
						var packageVolume = package.PackageCategory.Height * package.PackageCategory.Length * package.PackageCategory.Width;

						if (carVolume - packageVolume < 0)
						{
							carToFill = queue.Any() ? queue.Dequeue() : default;

							if (carToFill != null)
							{
								carVolume = carToFill.PhysicalParameters.Height * carToFill.PhysicalParameters.Length * carToFill.PhysicalParameters.Width;
								carToFill.AddPackage(package);
								package.Transport = carToFill;
								continue;
							}

							break;
						}

						carVolume -= packageVolume;
						carToFill.AddPackage(package);
						package.Transport = carToFill;
					}

					shipment.ChangeStatus();
				}
			}

			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Car assignment failed");
		}
	}
}
