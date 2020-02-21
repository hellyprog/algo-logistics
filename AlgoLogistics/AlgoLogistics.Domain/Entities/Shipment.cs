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
		private List<Package> packages;

		public int ShipmentId { get; private set; }
		public IEnumerable<Package> Packages
		{ 
			get { return packages; }
			private set { packages = value.ToList(); }
		}
		public Route Route { get; private set; }

		private Shipment()
		{
		}

		private Shipment(List<Package> packages)
		{
			this.packages = packages;
		}

		public static async Task<Shipment> CreateAsync(List<Package> packages)
		{
			var shipment = new Shipment(packages);
			shipment.Route = await BuildRoute();

			return shipment;
		}

		private static Task<Route> BuildRoute()
		{
			throw new NotImplementedException();
		}
	}
}
