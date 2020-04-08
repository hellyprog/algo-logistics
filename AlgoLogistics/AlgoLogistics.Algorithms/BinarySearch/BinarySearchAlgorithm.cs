using System;

namespace AlgoLogistics.Algorithms.BinarySearch
{
	public class BinarySearchAlgorithm : ISearchAlgorithm<BinarySearchAlgorithmInput, int?>
	{
		public int? Search(BinarySearchAlgorithmInput input)
		{
			var startIndex = 0;
			var endIndex = input.Source.Length - 1;

			Array.Sort(input.Source);

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
