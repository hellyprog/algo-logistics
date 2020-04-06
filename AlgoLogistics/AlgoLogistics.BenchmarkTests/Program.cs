using AlgoLogistics.Algorithms.Dijkstra;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

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
