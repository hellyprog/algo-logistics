using AlgoLogistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLogistics.Domain.Interfaces
{
	public interface IPackagesDataQuery
	{
		IQueryable<Package> GetPackages();
	}
}
