using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms.Dijkstra
{
	public class DijkstraAlgorithmInput
	{
		public int[,] AdjacencyMatrix { get; set; }
		public string Start { get; set; }
		public string End { get; set; }
		public Dictionary<string, int> NodeIndexMappings { get; set; }
	}
}
