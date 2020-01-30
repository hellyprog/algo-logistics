﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms.BinarySearch
{
	public class BinarySearchAlgorithm : IAlgorithm<BinarySearchAlgorithmInput, int?>
	{
		public int? Execute(BinarySearchAlgorithmInput input)
		{
			var startIndex = 0;
			var endIndex = input.Source.Length - 1;

			while (startIndex <= endIndex)
			{
				var middle = (startIndex + endIndex) / 2;
				var guess = input.Source[middle];

				if (guess == input.ValueToSearch)
				{
					return middle;
				}
				else if (guess > input.ValueToSearch)
				{
					endIndex = middle - 1;
				}
				else
				{
					startIndex = middle + 1;
				}
			}

			return null;
		}
	}
}