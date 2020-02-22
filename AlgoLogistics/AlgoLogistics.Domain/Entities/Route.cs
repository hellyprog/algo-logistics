using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Route
	{
		public Route(string startCity, string destinationCity, List<string> path)
		{
			this.StartCity = startCity ?? throw new ArgumentNullException(nameof(startCity));
			this.DestinationCity = destinationCity ?? throw new ArgumentNullException(nameof(destinationCity));
			this.Path = path ?? throw new ArgumentNullException(nameof(path));
		}

		public string StartCity { get; set; }
		public string DestinationCity { get; set; }
		public List<string> Path { get; set; }
	}
}
