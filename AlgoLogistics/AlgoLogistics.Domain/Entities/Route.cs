using AlgoLogistics.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace AlgoLogistics.Domain.Entities
{
	public class Route
	{
		public Route(string startCity, string destinationCity, double distance, Queue<string> path)
		{
			StartCity = !string.IsNullOrEmpty(startCity) ? startCity : throw new AlgoLogisticsException($"{nameof(startCity)} cannot be null or empty");
			DestinationCity = !string.IsNullOrEmpty(destinationCity) ? destinationCity : throw new AlgoLogisticsException($"{nameof(startCity)} cannot be null or empty");
			Path = path ?? throw new AlgoLogisticsException($"{nameof(path)} cannot be null");
			Distance = distance > 0 ? distance : throw new AlgoLogisticsException($"{nameof(distance)} cannot be less or equal to 0");
		}

		public string StartCity { get; set; }
		public string DestinationCity { get; set; }
		public double Distance { get; set; }
		public Queue<string> Path { get; set; }
	}
}
