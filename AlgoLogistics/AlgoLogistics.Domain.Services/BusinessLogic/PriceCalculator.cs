using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
using AlgoLogistics.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.BusinessLogic
{
	public class PriceCalculator : IPriceCalculator
	{
		private readonly ICityNetworkProvider _cityNetworkProvider;
		private readonly IApplicationDbContext _applicationDbContext;

		public PriceCalculator(ICityNetworkProvider cityNetworkProvider, IApplicationDbContext applicationDbContext)
		{
			_cityNetworkProvider = cityNetworkProvider;
			_applicationDbContext = applicationDbContext;
		}

		public async Task<Money> CalculateDeliveryPriceAsync(string fromCity, string toCity)
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
			var basePrice = _applicationDbContext.ApplicationConfigs.FirstOrDefault(x => x.ConfigName == "BaseDeliveryPrice")?.ConfigValue;
			var canParse = decimal.TryParse(basePrice, out decimal basePriceParsed);

			if (!canParse)
			{
				return default;
			}

			var amount = basePriceParsed + decimal.Divide((decimal)distance, 10m);
			return new Money(amount, "UAH");
		}
	}
}
