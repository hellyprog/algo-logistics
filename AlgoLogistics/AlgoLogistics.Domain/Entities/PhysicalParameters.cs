using AlgoLogistics.Domain.Common.Exceptions;
using System;

namespace AlgoLogistics.Domain.Entities
{
	public class PhysicalParameters
	{
		public double Length { get; private set; }
		public double Width { get; private set; }
		public double Height { get; private set; }

		private PhysicalParameters() { }

		public PhysicalParameters(double length, double width, double height)
		{
			if (width <= 0 || height <= 0 || length <= 0)
			{
				throw new AlgoLogisticsException("Parameters cannot be negative or equal to 0");
			}

			Width = width;
			Height = height;
			Length = length;
		}
	}
}
