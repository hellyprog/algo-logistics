using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class PackageCategory
	{
		public int PackageCategoryId { get; set; }
		public SizeCategory SizeCategory { get; set; }
		public double Length { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }
		public List<Package> Packages { get; set; }
	}
}
