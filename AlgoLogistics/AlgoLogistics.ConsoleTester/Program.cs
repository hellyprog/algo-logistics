using AlgoLogistics.Algorithms;
using AlgoLogistics.Algorithms.BFS;
using AlgoLogistics.Algorithms.BinarySearch;
using AlgoLogistics.Algorithms.QuickSort;
using AlgoLogistics.Algorithms.SelectionSort;
using AlgoLogistics.Application.Integration.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.ConsoleTester
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var provider = new CityNetworkProvider();
			var result = await provider.GetCityNetwork();
			Console.ReadKey();
		}
	}
}
