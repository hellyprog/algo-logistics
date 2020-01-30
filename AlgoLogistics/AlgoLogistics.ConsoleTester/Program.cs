using AlgoLogistics.Algorithms;
using AlgoLogistics.Algorithms.BinarySearch;
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
			var alg = new MeasurableAlgorithm<BinarySearchAlgorithmInput, int?>(new BinarySearchAlgorithm());

			var result = alg.Execute(new BinarySearchAlgorithmInput
			{
				ValueToSearch = 200,
				Source = Enumerable.Range(1, 1000000).ToArray()
			});

			Console.WriteLine(result.Value);
		}
	}
}
