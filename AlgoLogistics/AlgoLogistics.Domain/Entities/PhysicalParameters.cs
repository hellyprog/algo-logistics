using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class PhysicalParameters
	{
		public const double MaxDimensionValueInMetres = 1.5;
		public const double MaxWeightInKilograms = 50;

		public double Width { get; private set; }
		public double Height { get; private set; }
		public double Length { get; private set; }
		public double Weight { get; private set; }

		private PhysicalParameters() { }

		public PhysicalParameters(double width, double height, double length, double weight)
		{
			if (width <= 0 || height <= 0 || length <= 0 || weight <= 0)
			{
				throw new ArgumentException("Parameters cannot be negative or equal to zero");
			}

			if (width > MaxDimensionValueInMetres || height > MaxDimensionValueInMetres || length > MaxDimensionValueInMetres)
			{
				throw new ArgumentException($"Max dimension value is {MaxDimensionValueInMetres} metre(s)");
			}

			if (weight > MaxWeightInKilograms)
			{
				throw new ArgumentException($"Max weight value is {MaxWeightInKilograms} kg");
			}

			Width = width;
			Height = height;
			Length = length;
			Weight = weight;
		}
	}
}
