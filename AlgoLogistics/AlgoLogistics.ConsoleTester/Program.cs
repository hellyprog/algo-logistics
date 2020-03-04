using AlgoLogistics.Algorithms;
using AlgoLogistics.Algorithms.BFS;
using AlgoLogistics.Algorithms.BinarySearch;
using AlgoLogistics.Algorithms.QuickSort;
using AlgoLogistics.Algorithms.SelectionSort;
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
