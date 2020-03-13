using AlgoLogistics.Algorithms;
using AlgoLogistics.Algorithms.BFS;
using AlgoLogistics.Algorithms.BinarySearch;
using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Algorithms.QuickSort;
using AlgoLogistics.Algorithms.SelectionSort;
using AlgoLogistics.Application.Integration.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.ConsoleTester
{
	public class City
	{
		public string Name { get; set; }
		public List<ConnectedCity> Connections { get; set; }
	}

	public class ConnectedCity
	{
		public string Name { get; set; }
		public double Distance { get; set; }
	}

	class Program
	{
		static async Task Main(string[] args)
		{
			using var sr = new StreamReader(@"cities-network.json");
			var json = await sr.ReadToEndAsync();

			var network = JsonConvert.DeserializeObject<List<City>>(json);
			
			var algorithm = new DijkstraAlgorithm();
			var result = algorithm.Search(new DijkstraAlgorithmInput
			{ 
				Graph = ConvertToGraph(network),
				Start = "Lutsk",
				End = "Uzgorod"
			});

			Console.WriteLine(result.Value);
			Console.WriteLine(string.Join('-', result.Path));
			Console.ReadKey();
		}

		private static Dictionary<string, Dictionary<string, double>> ConvertToGraph(List<City> cityNetwork)
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
