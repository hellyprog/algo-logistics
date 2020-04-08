using System.Collections.Generic;

namespace AlgoLogistics.Algorithms.Dijkstra
{
	public class DijkstraAlgorithmInput
	{
		public Dictionary<string, Dictionary<string, double>> Graph { get; set; }
		public string Start { get; set; }
		public string End { get; set; }
	}
}
