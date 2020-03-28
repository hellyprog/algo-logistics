using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Common
{
	static class Utils
	{
		public static bool LessThan(this (double, double, double) parameters, (double, double, double) otherParameters)
		{
			return parameters.Item1 < otherParameters.Item1
				&& parameters.Item2 < otherParameters.Item2
				&& parameters.Item3 < otherParameters.Item3;
		}

		public static bool GreaterThan(this (double, double, double) parameters, (double, double, double) otherParameters)
		{
			return parameters.Item1 > otherParameters.Item1
				|| parameters.Item2 > otherParameters.Item2
				|| parameters.Item3 > otherParameters.Item3;
		}
	}
}
