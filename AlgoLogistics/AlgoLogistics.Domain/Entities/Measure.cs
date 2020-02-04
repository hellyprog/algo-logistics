using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Measure
	{
		public const double MaxDimensionValueInMetres = 1.5;
		public double Width { get; set; }
		public double Height { get; set; }
		public double Length { get; set; }

		public Measure(double width, double height, double length)
		{
			if (width <= 0 || height <= 0 || length <= 0)
			{
				throw new ArgumentException("Dimensions cannot be negative");
			}

			if (width > MaxDimensionValueInMetres || height > MaxDimensionValueInMetres || length > MaxDimensionValueInMetres)
			{
				throw new ArgumentException($"Max dimension value is {MaxDimensionValueInMetres} metre(s)");
			}

			Width = width;
			Height = height;
			Length = length;
		}
	}
}
