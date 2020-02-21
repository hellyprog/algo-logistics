using AlgoLogistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Interfaces
{
	public interface IShipmentService
	{
		Task<List<Shipment>> AssignPackagesToShipmentsAsync(List<Package> packages);
	}
}
