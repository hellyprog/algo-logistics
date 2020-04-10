using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Common.Exceptions
{
	public class AlgoLogisticsException : Exception
	{
		public AlgoLogisticsException(string message) : base(message)
		{

		}
	}
}
