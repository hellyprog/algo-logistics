using AlgoLogistics.Domain.Algorithms;
using AlgoLogistics.Domain.Algorithms.BinarySearch;
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
			var alg = new MeasurableAlgorithm<int[], int[]>(new SelectionSortAlgorithm());

			var result = alg.Execute(new int[] { 12, 3, 2, 6, 4, 1 });

			for (int i = 0; i < result.Length; i++)
			{
				Console.Write($"{result[i]}  ");
			}

			Console.ReadKey();
		}
	}
}
