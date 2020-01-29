using AlgoLogistics.Algorithms;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.ConsoleTester
{
	class A : IAlgorithm<int, int>
	{
		public int Execute(int input)
		{
			Thread.Sleep(1500);

			return input;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			var alg = new MeasurableAlgorithm<int, int>(new A());

			var result = alg.Execute(5);

			Console.WriteLine(result);
		}
	}
}
