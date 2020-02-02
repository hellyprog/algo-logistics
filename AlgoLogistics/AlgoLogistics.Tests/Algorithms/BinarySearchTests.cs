using AlgoLogistics.Algorithms.BinarySearch;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Tests.Algorithms
{
	public class BinarySearchTests
	{
		private BinarySearchAlgorithm _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new BinarySearchAlgorithm();
		}

		[Test]
		public void Execute_ReturnsPositionIndex_IfElementFound()
		{
			var testArray = new int[] { 1, 9, 15, 72 };

			var index = _sut.Execute(new BinarySearchAlgorithmInput
			{
				Source = testArray,
				ValueToSearch = 15
			});

			Assert.AreEqual(index, 2);
		}

		[Test]
		public void Execute_ReturnsPositionIndex_IfElementFoundInUnsortedArray()
		{
			var testArray = new int[] { 1, 9, 3, 72, 43 };

			var index = _sut.Execute(new BinarySearchAlgorithmInput
			{
				Source = testArray,
				ValueToSearch = 3
			});

			Assert.AreEqual(index, 1);
		}

		[Test]
		public void Execute_ReturnsNull_IfElementNotFound()
		{
			var testArray = new int[] { 1, 9, 15, 72 };

			var index = _sut.Execute(new BinarySearchAlgorithmInput
			{
				Source = testArray,
				ValueToSearch = 13
			});

			Assert.IsNull(index);
		}
	}
}
