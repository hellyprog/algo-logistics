using AlgoLogistics.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		public Shipment(List<Package> packages)
		{
			this.packages = packages;
		}
	}
}
