using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms.Dijkstra
{
	public class DijkstraAlgorithmInput
	{
		public Dictionary<string, Dictionary<string, int>> Graph { get; set; }
		public string Start { get; set; }
		public string End { get; set; }
	}
}
