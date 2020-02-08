using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms.SelectionSort
{
	public class SelectionSortAlgorithm : IAlgorithm<int[], int[]>
	{ 
		public int[] Execute(int[] input)
		{
			for (int i = 0; i < input.Length - 1; i++)
			{
				var currentElement = input[i];
				var minimumIndex = i;

				for (int j = i + 1; j < input.Length; j++)
				{
					if (input[i] > input[j])
					{
						minimumIndex = j;
					}
				}

				var temp = input[i];
				input[i] = input[minimumIndex];
				input[minimumIndex] = temp;
			}

			return input;
		}
	}
}
