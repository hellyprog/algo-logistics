using AlgoLogistics.Algorithms.Dijkstra;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Tests.Algorithms
{
	public class DijkstraAlgorithmTests
	{
		private DijkstraAlgorithm _sut;

		[SetUp]
		void Setup()
		{
			_sut = new DijkstraAlgorithm();
		}
	}
}
