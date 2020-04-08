using BenchmarkDotNet.Running;
using System;

namespace AlgoLogistics.BenchmarkTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<DijkstraAlgorithmBenchmark>();
            Console.ReadKey();
        }
    }
}
