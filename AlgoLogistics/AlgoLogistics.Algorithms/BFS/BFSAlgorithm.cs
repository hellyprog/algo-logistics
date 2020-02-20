using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Algorithms.BFS
{
	public class BFSAlgorithm : IAlgorithm<BFSAlgorithmInput, bool>
	{
		public bool Execute(BFSAlgorithmInput input)
		{
			var queue = new Queue<Node>();

			foreach (var city in input.Root.Nodes)
			{
				queue.Enqueue(city);
			}

			while (queue.Count > 0)
			{
				var node = queue.Dequeue();

				if (node.Name == input.NameToSearch)
				{
					return true;
				}
				else
				{
					foreach (var item in node.Nodes)
					{
						queue.Enqueue(item);
					}
				}
			}

			return false;
		}
	}
}
