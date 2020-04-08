using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services.Implementation;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AlgoLogistics.Tests.Domain
{
	public class PackageTests
	{
		private Mock<ICityNetworkProvider> _cityProvider;
		private IPriceCalculator _priceCalculator;
		private List<City> _network;

		[SetUp]
		public void Setup()
		{
			using var sr = new StreamReader(@"Algorithms/cities-network.json");
			var json = sr.ReadToEnd();

			_network = JsonConvert.DeserializeObject<List<City>>(json);
			_cityProvider = new Mock<ICityNetworkProvider>();
			_priceCalculator = new PriceCalculator(_cityProvider.Object);
		}

		[Test]
		public async Task PackageDeliveryPrice_FromLvivToUzgorod_ShouldBeEqualTo46Point7()
		{
			_cityProvider.Setup(x => x.GetCityNetworkAsync()).ReturnsAsync(_network);
			var package = await Package.CreateAsync(
				"desc",
				20,
				new PhysicalParameters(20, 20, 20),
				new DeliveryDetails("s", "r", "Lviv", "Uzgorod"),
				new PackageCategory(),
				_priceCalculator);

			Assert.AreEqual(package.DeliveryPrice, 46.7);
		}
	}
}
