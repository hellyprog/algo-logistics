﻿using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Common.Exceptions;
using AlgoLogistics.Domain.Enums;
using AlgoLogistics.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Entities
{
	public class Shipment : AuditableEntity
	{
		public int ShipmentId { get; private set; }
		public List<Package> Packages { get; private set; }
		public Route Route { get; private set; }
		public ShipmentStatus ShipmentStatus { get; private set; }

		private Shipment()
		{
		}

		private Shipment(List<Package> packages, Route route)
		{
			Packages = packages;
			Route = route;
			ShipmentStatus = ShipmentStatus.PackagesGrouped;
		}

		public void ChangeStatus()
		{
			ShipmentStatus = ShipmentStatus switch
			{
				Enums.ShipmentStatus.PackagesGrouped => Enums.ShipmentStatus.TransportAssigned,
				Enums.ShipmentStatus.TransportAssigned => Enums.ShipmentStatus.Shipping,
				Enums.ShipmentStatus.Shipping => Enums.ShipmentStatus.Shipped,
				_ => throw new AlgoLogisticsException($"Invalid emun value: {ShipmentStatus}")
			};
		}

		public bool RemovePackage(Package package)
		{
			return Packages.Remove(package);
		}

		public static async Task<Shipment> CreateAsync(List<Package> packages, ICityNetworkProvider cityNetworkProvider)
		{
			var route = await BuildRouteAsync(packages, cityNetworkProvider);
			packages.ForEach(x => x.ChangeStatus());
			var shipment = new Shipment(packages, route);

			return shipment;
		}

		private static async Task<Route> BuildRouteAsync(List<Package> packages, ICityNetworkProvider cityNetworkProvider)
		{
			var startCity = packages.First().DeliveryDetails.FromCity;
			var destinationCity = packages.First().DeliveryDetails.ToCity;
			var cityNetwork = await cityNetworkProvider.GetCityNetworkAsync();
			var graph = Utils.ConvertToGraph(cityNetwork);

			var searchAlgorithm = new DijkstraAlgorithm();
			var algorithmResult = searchAlgorithm.Search(new DijkstraAlgorithmInput
			{
				Start = startCity,
				End = destinationCity,
				Graph = graph
			});

			var route = new Route(startCity, destinationCity, algorithmResult.Value, algorithmResult.Path);

			return route;
		}
	}
}
