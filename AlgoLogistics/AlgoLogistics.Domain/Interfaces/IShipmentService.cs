using AlgoLogistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Interfaces
{
	public interface IShipmentService
	{
		List<Shipment> AssignPackagesToShipments(List<Package> packages);
	}
}
