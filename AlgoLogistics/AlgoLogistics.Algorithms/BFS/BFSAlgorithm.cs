using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms.BFS
{
	public class BFSAlgorithm : IAlgorithm<BFSAlgorithmInput, bool>
	{
		public bool Execute(BFSAlgorithmInput input)
		{
			var queue = new Queue<Node>();
			var checkedNodes = new HashSet<Node>();

			foreach (var city in input.Root.Nodes)
			{
				queue.Enqueue(city);
			}

			while (queue.Count > 0)
			{
				var node = queue.Dequeue();
				
				if (!checkedNodes.Contains(node))
				{
					if (node.Name == input.NameToSearch)
					{
						return true;
					}
					else
					{
						checkedNodes.Add(node);

						foreach (var item in node.Nodes)
						{
							queue.Enqueue(item);
						}
					} 
				}
			}

			return false;
		}
	}
}
