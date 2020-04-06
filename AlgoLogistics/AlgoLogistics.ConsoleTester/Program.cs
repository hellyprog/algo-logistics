﻿using AlgoLogistics.Algorithms;
using AlgoLogistics.Algorithms.BFS;
using AlgoLogistics.Algorithms.BinarySearch;
using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Algorithms.QuickSort;
using AlgoLogistics.Algorithms.SelectionSort;
using AlgoLogistics.Application.Integration.Services;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.ConsoleTester
{
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
				Graph = Utils.ConvertToGraph(network),
				Start = "Lutsk",
				End = "Uzgorod"
			});

			Console.WriteLine(result.Value);
			Console.WriteLine(string.Join('-', result.Path));
			Console.ReadKey();
		}
	}
}
