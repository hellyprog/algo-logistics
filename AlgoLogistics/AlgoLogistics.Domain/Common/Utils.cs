using AlgoLogistics.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AlgoLogistics.Domain.Common
{
	public static class Utils
	{
		public static Dictionary<string, Dictionary<string, double>> ConvertToGraph(List<City> cityNetwork)
		{
			var graphDictionary = new Dictionary<string, Dictionary<string, double>>();

			foreach (var city in cityNetwork)
			{
				var key = city.Name;
				var value = city.Connections.ToDictionary(x => x.Name, x => x.Distance);

				graphDictionary.Add(key, value);
			}

			return graphDictionary;
		}
	}
}
