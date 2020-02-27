using AlgoLogistics.Domain.Algorithms;
using AlgoLogistics.Domain.Algorithms.BFS;
using AlgoLogistics.Domain.Algorithms.BinarySearch;
using AlgoLogistics.Domain.Algorithms.QuickSort;
using AlgoLogistics.Domain.Algorithms.SelectionSort;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.ConsoleTester
{
	class Program
	{
		static void Main(string[] args)
		{
			var alg = new BFSAlgorithm();

			var result = alg.Execute(new BFSAlgorithmInput { NameToSearch = "Kamianets" });

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
