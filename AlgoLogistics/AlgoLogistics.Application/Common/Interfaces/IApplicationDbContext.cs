using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<Package> Packages { get; set; }
		DbSet<Shipment> Shipments { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
