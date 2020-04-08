using System;
using System.Collections.Generic;
using System.Linq;

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
			costs.Add(input.Start, 0);

			var parents = nodesToProcess.ToDictionary(x => x.Key,
				x => knownConnections.Keys.Contains(x.Key) ? input.Start : null);

			var processedNodes = new List<string>();

			var node = FindLowestCostNode(costs, processedNodes);

			while (!string.IsNullOrEmpty(node))
			{
				var cost = costs[node];
				var neighbours = input.Graph[node];

				foreach (var item in neighbours.Keys)
				{
					var newCost = cost + neighbours[item];

					if (costs[item] > newCost)
					{
						costs[item] = newCost;
						parents[item] = node;
					}

					processedNodes.Add(node);
				}

				node = FindLowestCostNode(costs, processedNodes);
			}

			return new DijkstraAlgorithmOutput
			{
				Value = costs[input.End],
				Path = GetPath(parents, input.End)
			};
		}

		private Queue<string> GetPath(Dictionary<string, string> parents, string end)
		{
			var result = new List<string>
			{
				end
			};

			var keyToGet = end;

			while (parents.TryGetValue(keyToGet, out keyToGet))
			{
				result.Add(keyToGet);
			}

			result.Reverse();

			return new Queue<string>(result);
		}

		private string FindLowestCostNode(Dictionary<string, double> costs, List<string> processedNodes)
		{
			var lowestValue = double.PositiveInfinity;
			KeyValuePair<string, double> lowestCostNode = default;
			var costsToProcess = costs.Where(c => !processedNodes.Contains(c.Key));

			foreach (var item in costsToProcess)
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
