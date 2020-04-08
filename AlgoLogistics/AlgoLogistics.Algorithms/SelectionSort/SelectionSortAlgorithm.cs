namespace AlgoLogistics.Algorithms.SelectionSort
{
	public class SelectionSortAlgorithm : ISortAlgorithm<int[], int[]>
	{
		public int[] Sort(int[] input)
		{
			for (int i = 0; i < input.Length - 1; i++)
			{
				var smallestElement = input[i];
				var minimumIndex = i;

				for (int j = i + 1; j < input.Length; j++)
				{
					if (input[j] < smallestElement)
					{
						smallestElement = input[j];
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
