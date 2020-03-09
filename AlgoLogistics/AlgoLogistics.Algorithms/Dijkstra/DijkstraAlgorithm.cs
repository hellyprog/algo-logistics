using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLogistics.Algorithms.Dijkstra
{
	public class DijkstraAlgorithm : ISearchAlgorithm<DijkstraAlgorithmInput, DijkstraAlgorithmOutput>
	{
		public DijkstraAlgorithmOutput Search(DijkstraAlgorithmInput input)
		{
			var knownConnections = input.Graph.FirstOrDefault(g => g.Key == input.Start).Value;
			var nodesToProcess = input.Graph.Where(g => g.Key != input.Start);

			var costs = nodesToProcess.ToDictionary(x => x.Key,
				x => knownConnections.Keys.Contains(x.Key) ? knownConnections[x.Key] : double.PositiveInfinity);
			var parents = nodesToProcess.ToDictionary(x => x.Key,
				x => knownConnections.Keys.Contains(x.Key) ? input.Start : null);

			var processedNodes = new List<string>();

			var node = FindLowestCostNode(costs, processedNodes);

			throw new NotImplementedException();
		}

		private string FindLowestCostNode(Dictionary<string, double> costs, List<string> processedNodes)
		{
			var lowestValue = double.PositiveInfinity;
			KeyValuePair<string, double> lowestCostNode = default;

			foreach (var item in costs)
			{
				if (item.Value < lowestValue)
				{
					lowestValue = item.Value;
					lowestCostNode = item;
				}
			}

			return lowestCostNode.Key;
		}
	}
}
