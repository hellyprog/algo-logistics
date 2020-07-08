using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AlgoLogistics.Domain.Entities
{
	public class PackageCategory : IComparable<PackageCategory>
	{
		public int PackageCategoryId { get; set; }
		public SizeCategory SizeCategory { get; set; }
		public double Length { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }
		public List<Package> Packages { get; set; }

		public int CompareTo([AllowNull] PackageCategory other)
		{
			if (other == null) return 1;

			var thisSizes = (Length, Width, Height);
			var otherSizes = (other.Length, other.Width, other.Height);

			return thisSizes.CompareTo(otherSizes);
		}
	}
}
