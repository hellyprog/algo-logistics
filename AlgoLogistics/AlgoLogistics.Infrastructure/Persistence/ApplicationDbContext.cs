using AlgoLogistics.Application.Common.Interfaces;
using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);
		}
	}
}
