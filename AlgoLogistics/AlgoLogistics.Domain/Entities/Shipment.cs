using AlgoLogistics.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Shipment : AuditableEntity
	{
		public int Id { get; set; }
		public List<Package> Packages { get; set; }
		public Route Route { get; set; }
	}
}
