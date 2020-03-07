﻿using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Interfaces;
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

		public static async Task<Shipment> CreateAsync(List<Package> packages, ICityNetworkProvider cityNetworkProvider)
		{
			var shipment = new Shipment(packages)
			{
				Route = await BuildRoute(packages, cityNetworkProvider)
			};

			return shipment;
		}

		private static Task<Route> BuildRoute(List<Package> packages, ICityNetworkProvider cityNetworkProvider)
		{
			var startCity = packages.First().DeliveryDetails.FromCity;
			var destinationCity = packages.First().DeliveryDetails.ToCity;
			var cityNetwork = cityNetworkProvider.GetCityNetwork();
			throw new NotImplementedException();
		}
	}
}
