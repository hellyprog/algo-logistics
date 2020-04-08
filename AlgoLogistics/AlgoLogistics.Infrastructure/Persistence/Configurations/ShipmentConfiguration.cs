using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoLogistics.Infrastructure.Persistence.Configurations
{
	public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
	{
		public void Configure(EntityTypeBuilder<Shipment> builder)
		{
			builder.ToTable("Shipments");

			builder.HasKey(p => p.ShipmentId);
			builder.Property(p => p.ShipmentId).HasColumnName("shipment_id").IsRequired();
			builder.OwnsOne(p => p.Route,
				route =>
				{
					route.Property(p => p.StartCity).HasColumnName("start_city").IsRequired();
					route.Property(p => p.DestinationCity).HasColumnName("destination_city").IsRequired();
					route.Property(p => p.Distance).HasColumnName("distance").IsRequired();
					route.Property(p => p.Path)
						.HasConversion(p => string.Join('-', p), p => new Queue<string>(p.Split('-', StringSplitOptions.RemoveEmptyEntries).ToList()))
						.HasColumnName("path")
						.IsRequired();
				});

			builder.HasMany(p => p.Packages)
				   .WithOne(p => p.Shipment)
				   .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

			builder.Property(p => p.Created).HasColumnName("created");
			builder.Property(p => p.CreatedBy).HasColumnName("created_by");
			builder.Property(p => p.LastModified).HasColumnName("last_modified");
			builder.Property(p => p.LastModifiedBy).HasColumnName("last_modified_by");

		}
	}
}
