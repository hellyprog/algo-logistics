using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Entities;
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
                new City { CityId = 1, Name = "Lviv" },
                new City { CityId = 2, Name = "Uzgorod" },
                new City { CityId = 3, Name = "Lutsk" },
                new City { CityId = 4, Name = "Rivne" },
                new City { CityId = 5, Name = "Ternopil" },
                new City { CityId = 6, Name = "Ivano-Frankivsk" },
                new City { CityId = 7, Name = "Chernivtsi" },
                new City { CityId = 8, Name = "Zhytomyr" },
                new City { CityId = 9, Name = "Khmelnytskyi" },
                new City { CityId = 10, Name = "Vinnytsia" }
            );
		}
	}
}
