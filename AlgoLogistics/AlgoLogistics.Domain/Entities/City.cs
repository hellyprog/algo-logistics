using System.Collections.Generic;

namespace AlgoLogistics.Domain.Entities
{
	public class City
	{
		public int CityId { get; set; }
		public string Name { get; set; }
		public List<ConnectedCity> Connections { get; set; }
	}
}
