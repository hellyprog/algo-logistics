using AlgoLogistics.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Entities
{
	public class Shipment : AuditableEntity
	{
		private HashSet<Package> _packages;

		public int ShipmentId { get; private set; }
		public IEnumerable<Package> Packages => _packages?.ToList();
		public Route Route { get; private set; }

		private Shipment()
		{
		}

		private Shipment(List<Package> packages)
		{
			_packages = packages.ToHashSet();
		}

		public static async Task<Shipment> CreateAsync(List<Package> packages)
		{
			var shipment = new Shipment(packages);
			shipment.Route = await BuildRoute(packages);

			return shipment;
		}

		private static Task<Route> BuildRoute(List<Package> packages)
		{
			var startCity = packages.First().DeliveryDetails.FromCity;
			var destinationCity = packages.First().DeliveryDetails.ToCity;
			throw new NotImplementedException();
		}
	}
}
