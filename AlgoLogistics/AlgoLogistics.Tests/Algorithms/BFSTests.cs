using AlgoLogistics.Domain.Algorithms.BFS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Tests.Algorithms
{
	public class BFSTests
	{
		private BFSAlgorithm _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new BFSAlgorithm();
		}

		[Test]
		public void Execute_ReturnsTrue_IfNodeIsFound()
		{
			var input = new BFSAlgorithmInput
			{
				Root = BuildGraph(true),
				NameToSearch = "Rivne"
			};

			var result = _sut.Execute(input);

			Assert.IsTrue(result);
		}

		[Test]
		public void Execute_ReturnsFalse_IfNodeIsNotFound()
		{
			var input = new BFSAlgorithmInput
			{
				Root = BuildGraph(),
				NameToSearch = "Kyiv"
			};

			var result = _sut.Execute(input);

			Assert.IsFalse(result);
		}

		private Node BuildGraph(bool loopEnabled = false)
		{
			var lviv = new Node { Name = "Lviv", Nodes = new List<Node>() };
			var lutsk = new Node { Name = "Lutsk", Nodes = new List<Node>() };
			var ternopil = new Node { Name = "Ternopil", Nodes = new List<Node>() };

			lviv.Nodes.Add(lutsk);
			lviv.Nodes.Add(ternopil);

			var kamianets = new Node { Name = "Kamianets", Nodes = new List<Node>() };
			var rivne = new Node { Name = "Rivne", Nodes = new List<Node>() };

			if (loopEnabled)
			{
				lutsk.Nodes.Add(lviv);
				lutsk.Nodes.Add(rivne);
			}
			else
			{
				lutsk.Nodes.Add(rivne);
				ternopil.Nodes.Add(kamianets);
			}

			return lviv;
		}
	}
}
