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
    public class City
    {
        public string Name { get; set; }
        public List<ConnectedCity> Connections { get; set; }
    }

    public class ConnectedCity
    {
        public string Name { get; set; }
        public double Distance { get; set; }
    }

    [MemoryDiagnoser]
    public class Algorithms
    {
        DijkstraAlgorithm dijkstra;
        DijkstraAlgorithmInput input;

        public Algorithms()
        {
            using var sr = new StreamReader(@"cities-network.json");
            var json = sr.ReadToEnd();

            var network = JsonConvert.DeserializeObject<List<City>>(json);

            dijkstra = new DijkstraAlgorithm();
            input = new DijkstraAlgorithmInput
            {
                Graph = ConvertToGraph(network),
                Start = "Lutsk",
                End = "Uzgorod"
            };
        }

        private static Dictionary<string, Dictionary<string, double>> ConvertToGraph(List<City> cityNetwork)
        {
            var graphDictionary = new Dictionary<string, Dictionary<string, double>>();

            foreach (var city in cityNetwork)
            {
                var key = city.Name;
                var value = city.Connections.ToDictionary(x => x.Name, x => x.Distance);

                graphDictionary.Add(key, value);
            }

            return graphDictionary;
        }

        [Benchmark]
        public DijkstraAlgorithmOutput DijkstraRun() => dijkstra.Search(input);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<Algorithms>();
            Console.ReadKey();
        }
    }
}
