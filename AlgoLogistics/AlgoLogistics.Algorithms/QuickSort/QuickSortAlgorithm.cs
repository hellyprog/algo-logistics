using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms.QuickSort
{
	public class QuickSortAlgorithm : IAlgorithm<int[], int[]>
	{
		public int[] Execute(int[] input)
		{
			if (input.Length < 2)
			{
				return input;
			}
			else
			{
				var pivotIndex = input.Length / 2;
				var pivot = input[pivotIndex];
				var lessThanPivot = new List<int>();
				var greaterThanPivot = new List<int>();

				for (int i = 0; i < input.Length; i++)
				{
					if (i != pivotIndex)
					{
						if (input[i] <= pivot)
						{
							lessThanPivot.Add(input[i]);
						}
						else
						{
							greaterThanPivot.Add(input[i]);
						} 
					}
				}

				var sortedLess = Execute(lessThanPivot.ToArray());
				var sortedGreater = Execute(greaterThanPivot.ToArray());
				var resultList = new List<int>();
				resultList.AddRange(sortedLess);
				resultList.Add(pivot);
				resultList.AddRange(sortedGreater);

				return resultList.ToArray();
			}
		}
	}
}
