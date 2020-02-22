using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLogistics.Application.DataQueries
{
	public class PackagesDataQuery : IPackagesDataQuery
	{
		public IQueryable<Package> GetPackages()
		{
			throw new NotImplementedException();
		}
	}
}
