using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
using AlgoLogistics.Infrastructure.Persistence.DefaultData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Package> Packages { get; set; }
		public DbSet<Shipment> Shipments { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<PackageCategory> PackageCategories { get; set; }
		public DbSet<ApplicationConfig> ApplicationConfigs { get; set; }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.Created = DateTime.Now;
						break;
					case EntityState.Modified:
						entry.Entity.LastModified = DateTime.Now;
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);

			builder.Entity<City>().HasData(DefaultDataProvider.GetCities());
			builder.Entity<PackageCategory>().HasData(DefaultDataProvider.GetPackageCategories());

			builder.Entity<ApplicationConfig>().HasData(DefaultDataProvider.GetApplicationConfigs());
		}
	}
}
