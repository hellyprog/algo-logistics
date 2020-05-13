using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class ApplicationConfig
	{
		public int ApplicationConfigId { get; set; }
		public string ConfigName { get; set; }
		public string ConfigValue { get; set; }
	}
}
