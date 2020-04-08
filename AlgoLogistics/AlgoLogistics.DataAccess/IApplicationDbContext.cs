using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.DataAccess
{
	public interface IApplicationDbContext
	{
		DbSet<Package> Packages { get; set; }
		DbSet<Shipment> Shipments { get; set; }
		DbSet<City> Cities { get; set; }
		DbSet<PackageCategory> PackageCategories { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
