using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class City
	{
		public int CityId { get; set; }
		public string Name { get; set; }
		public List<ConnectedCity> Connections { get; set; }
	}
}
