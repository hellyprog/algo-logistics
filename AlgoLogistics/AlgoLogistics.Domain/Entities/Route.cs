using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Route
	{
		public Route(string startCity, string destinationCity, double distance, Queue<string> path)
		{
			StartCity = startCity ?? throw new ArgumentNullException(nameof(startCity));
			DestinationCity = destinationCity ?? throw new ArgumentNullException(nameof(destinationCity));
			Path = path ?? throw new ArgumentNullException(nameof(path));
			Distance = distance > 0 ? distance : throw new ArgumentException(nameof(distance));
		}

		public string StartCity { get; set; }
		public string DestinationCity { get; set; }
		public double Distance { get; set; }
		public Queue<string> Path { get; set; }
	}
}
