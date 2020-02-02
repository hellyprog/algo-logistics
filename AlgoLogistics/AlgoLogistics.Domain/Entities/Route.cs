using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Route
	{
		public int Id { get; set; }
		public string StartCity { get; set; }
		public string DestinationCity { get; set; }
		public List<string> Path { get; set; }
	}
}
