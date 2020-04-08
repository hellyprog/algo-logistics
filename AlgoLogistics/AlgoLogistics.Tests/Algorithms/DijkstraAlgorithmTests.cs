using AlgoLogistics.Algorithms.Dijkstra;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AlgoLogistics.Tests.Algorithms
{
	[TestFixture]
	public class DijkstraAlgorithmTests
	{
		private DijkstraAlgorithm _sut;
		private Dictionary<string, Dictionary<string, double>> _graph;

		[SetUp]
		public void Setup()
		{
			_sut = new DijkstraAlgorithm();

			using var sr = new StreamReader(@"Algorithms/cities-network.json");
			var json = sr.ReadToEnd();

			var network = JsonConvert.DeserializeObject<List<City>>(json);
			_graph = Utils.ConvertToGraph(network);
		}

		[TestCaseSource(typeof(DijkstraAlgorithmDataClass), "Data")]
		public double ExectuteTests(string start, string end)
		{
			var input = new DijkstraAlgorithmInput
			{
				Graph = _graph,
				Start = start,
				End = end
			};

			var result = _sut.Search(input);

			return result.Value;
		}
	}

	internal class DijkstraAlgorithmDataClass
	{
		public static IEnumerable Data
		{
			get
			{
				yield return new TestCaseData("Lutsk", "Uzgorod").Returns(417);
				yield return new TestCaseData("Lviv", "Chernivtsi").Returns(269);
				yield return new TestCaseData("Chernivtsi", "Zhytomyr").Returns(370);
				yield return new TestCaseData("Lviv", "Ternopil").Returns(133);
				yield return new TestCaseData("Lviv", "Vinnytsia").Returns(363);
			}
		}
	}
}
