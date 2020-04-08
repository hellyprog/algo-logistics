using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AlgoLogistics.BenchmarkTests
{
	[MemoryDiagnoser]
	public class DijkstraAlgorithmBenchmark
	{
		private readonly DijkstraAlgorithm dijkstra;
		private readonly DijkstraAlgorithmInput input;

		public DijkstraAlgorithmBenchmark()
		{
			using var sr = new StreamReader(@"cities-network.json");
			var json = sr.ReadToEnd();

			var network = JsonConvert.DeserializeObject<List<City>>(json);

			dijkstra = new DijkstraAlgorithm();
			input = new DijkstraAlgorithmInput
			{
				Graph = Utils.ConvertToGraph(network),
				Start = "Lutsk",
				End = "Uzgorod"
			};
		}

		[Benchmark]
		public DijkstraAlgorithmOutput DijkstraRun() => dijkstra.Search(input);
	}
}
