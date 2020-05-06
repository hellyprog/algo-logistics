using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
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

			builder.Entity<City>().HasData(
				new City { CityId = 1, Name = "Lviv", Country = "Ukraine" },
				new City { CityId = 2, Name = "Uzgorod", Country = "Ukraine" },
				new City { CityId = 3, Name = "Lutsk", Country = "Ukraine" },
				new City { CityId = 4, Name = "Rivne", Country = "Ukraine" },
				new City { CityId = 5, Name = "Ternopil", Country = "Ukraine" },
				new City { CityId = 6, Name = "Ivano-Frankivsk", Country = "Ukraine" },
				new City { CityId = 7, Name = "Chernivtsi", Country = "Ukraine" },
				new City { CityId = 8, Name = "Zhytomyr", Country = "Ukraine" },
				new City { CityId = 9, Name = "Khmelnytskyi", Country = "Ukraine" },
				new City { CityId = 10, Name = "Vinnytsia", Country = "Ukraine" }
			);

			builder.Entity<PackageCategory>().HasData(
					new PackageCategory
					{
						PackageCategoryId = 1,
						SizeCategory = SizeCategory.ExtraSmall,
						Length = 0.2,
						Width = 0.15,
						Height = 0.05
					},
					new PackageCategory
					{
						PackageCategoryId = 2,
						SizeCategory = SizeCategory.Small,
						Length = 0.3,
						Width = 0.2,
						Height = 0.1
					},
					new PackageCategory
					{
						PackageCategoryId = 3,
						SizeCategory = SizeCategory.Medium,
						Length = 0.3,
						Width = 0.3,
						Height = 0.2
					},
					new PackageCategory
					{
						PackageCategoryId = 4,
						SizeCategory = SizeCategory.Large,
						Length = 0.4,
						Width = 0.3,
						Height = 0.3
					},
					new PackageCategory
					{
						PackageCategoryId = 5,
						SizeCategory = SizeCategory.ExtraLarge,
						Length = 0.45,
						Width = 0.3,
						Height = 0.3
					}
				);
		}
	}
}
