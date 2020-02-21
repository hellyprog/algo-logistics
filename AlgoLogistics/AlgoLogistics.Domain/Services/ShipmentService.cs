using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services
{
	public class ShipmentService : IShipmentService
	{
		public async Task<List<Shipment>> AssignPackagesToShipmentsAsync(List<Package> packages)
		{
			if (packages == null || packages.Count == 0)
			{
				throw new ArgumentException("Packages cannot be null or empty");
			}

			var shipmentList = new List<Shipment>();

			var groupedPackagesByFromCity = from package in packages
											where package.Status == Enums.DeliveryStatus.NotSent
											&& package.Created.Date == DateTime.Now.AddDays(-1).Date
											group package by package.DeliveryDetails.FromCity into g
											select new { g.Key, Grouped = g };

			foreach (var groupedPackageByFromCity in groupedPackagesByFromCity)
			{
				var groupedPackagesByToCity = from package in groupedPackageByFromCity.Grouped
											  group package by package.DeliveryDetails.ToCity into g
											  select new { g.Key, Grouped = g };

				foreach (var package in groupedPackagesByToCity)
				{
					var shipment = await Shipment.CreateAsync(package.Grouped.ToList());
					shipmentList.Add(shipment);
				}
			}

			return shipmentList;
		}
	}
}
