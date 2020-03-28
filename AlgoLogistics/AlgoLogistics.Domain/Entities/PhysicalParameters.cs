using System;
using System.Collections.Generic;
using System.Text;

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
				throw new ArgumentException("Parameters cannot be negative or equal to zero");
			}

			Width = width;
			Height = height;
			Length = length;
		}
	}
}
