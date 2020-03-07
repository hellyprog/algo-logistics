using AlgoLogistics.Algorithms.SelectionSort;
using NUnit.Framework;
using System;
using System.Linq;

namespace AlgoLogistics.Tests.Algorithms
{
	public class SelectionSortTests
	{
		private SelectionSortAlgorithm _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new SelectionSortAlgorithm();
		}

		[Test]
		public void Execute_ReturnsSortedArray_ForGivenInput()
		{
			var input = new int[] { 3, 20, 9, 0, 4, 6 };

			var output = _sut.Sort(input);
			var expected = input.OrderBy(x => x);

			Assert.IsTrue(expected.SequenceEqual(output));
		}
	}
}
