using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.Implementation
{
	public class PriceCalculator : IPriceCalculator
	{
		private readonly ICityNetworkProvider _cityNetworkProvider;

		public PriceCalculator(ICityNetworkProvider cityNetworkProvider)
		{
			_cityNetworkProvider = cityNetworkProvider;
		}

		public async Task<decimal> CalculateDeliveryPriceAsync(string fromCity, string toCity)
		{
			var cityNetwork = await _cityNetworkProvider.GetCityNetworkAsync();
			var graph = Utils.ConvertToGraph(cityNetwork);

			var searchAlgorithm = new DijkstraAlgorithm();
			var algorithmResult = searchAlgorithm.Search(new DijkstraAlgorithmInput
			{
				Start = fromCity,
				End = toCity,
				Graph = graph
			});

			var distance = algorithmResult.Value;
			var basePrice = 20m;

			return basePrice + decimal.Divide((decimal)distance, 10m);
		}
	}
}
