using AlgoLogistics.Algorithms;
using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Domain.Common;
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
		private readonly HashSet<Package> _packages;

		public int ShipmentId { get; private set; }
		public IEnumerable<Package> Packages => _packages?.ToList();
		public Route Route { get; private set; }

		private Shipment()
		{
		}

		private Shipment(List<Package> packages, Route route)
		{
			_packages = packages.ToHashSet();
			Route = route;
		}

		public static async Task<Shipment> CreateAsync(List<Package> packages, ICityNetworkProvider cityNetworkProvider)
		{
			var route = await BuildRouteAsync(packages, cityNetworkProvider);
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
