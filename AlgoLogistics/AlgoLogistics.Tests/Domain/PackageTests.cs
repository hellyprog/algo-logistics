using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services.BusinessLogic;
using Microsoft.EntityFrameworkCore;
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
		private Mock<IApplicationDbContext> _applicationDbContext;

		[SetUp]
		public void Setup()
		{
			using var sr = new StreamReader(@"Algorithms/cities-network.json");
			var json = sr.ReadToEnd();

			_network = JsonConvert.DeserializeObject<List<City>>(json);
			_cityProvider = new Mock<ICityNetworkProvider>();
			_applicationDbContext = new Mock<IApplicationDbContext>();
			_priceCalculator = new PriceCalculator(_cityProvider.Object, _applicationDbContext.Object);
		}
	}
}
