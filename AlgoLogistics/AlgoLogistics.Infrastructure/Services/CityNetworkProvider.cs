using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AlgoLogistics.Infrastructure.Services
{
	public class CityNetworkProvider : ICityNetworkProvider
	{
		public async Task<List<City>> GetCityNetworkAsync()
		{
			using var sr = new StreamReader(@"cities-network.json");
			var json = await sr.ReadToEndAsync();

			var network = JsonConvert.DeserializeObject<List<City>>(json);
			return network;
		}
	}
}
