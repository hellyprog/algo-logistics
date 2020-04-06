using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlgoLogistics.BenchmarkTests
{ 
    [MemoryDiagnoser]
    public class DijkstraAlgorithmBenchmark
    {
        DijkstraAlgorithm dijkstra;
        DijkstraAlgorithmInput input;

        public DijkstraAlgorithmBenchmark()
        {
            using var sr = new StreamReader(@"cities-network.json");
            var json = sr.ReadToEnd();

            var network = JsonConvert.DeserializeObject<List<City>>(json);

            dijkstra = new DijkstraAlgorithm();
            input = new DijkstraAlgorithmInput
            {
                Graph = Utils.ConvertToGraph(network),
                Start = "Lutsk",
                End = "Uzgorod"
            };
        }

        [Benchmark]
        public DijkstraAlgorithmOutput DijkstraRun() => dijkstra.Search(input);
    }
}
