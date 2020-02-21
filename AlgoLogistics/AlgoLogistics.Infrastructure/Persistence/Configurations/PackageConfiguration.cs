using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Infrastructure.Persistence.Configurations
{
	public class PackageConfiguration : IEntityTypeConfiguration<Package>
	{
		public void Configure(EntityTypeBuilder<Package> builder)
		{
			var deliveryStatusConverter = new EnumToStringConverter<DeliveryStatus>();

			builder.ToTable("Packages");

			builder.HasKey(p => p.PackageId);
			builder.Property(p => p.PackageId).HasColumnName("package_id");
			builder.Property(p => p.Description).HasColumnName("description").IsRequired();
			builder.Property(p => p.Price).HasColumnName("price").IsRequired();
			builder.Property(p => p.DeliveryPrice).HasColumnName("delivery_price").IsRequired();
			builder.Property(p => p.Status).HasColumnName("status").IsRequired().HasConversion(deliveryStatusConverter);
			builder.OwnsOne(p => p.PhysicalParameters,
				parameters =>
				{
					parameters.Property(p => p.Height).HasColumnName("height").IsRequired();
					parameters.Property(p => p.Length).HasColumnName("length").IsRequired();
					parameters.Property(p => p.Weight).HasColumnName("weight").IsRequired();
					parameters.Property(p => p.Width).HasColumnName("width").IsRequired();
				});
			builder.OwnsOne(p => p.DeliveryDetails,
				parameters =>
				{
					parameters.Property(p => p.FromCity).HasColumnName("from_city").IsRequired();
					parameters.Property(p => p.ToCity).HasColumnName("to_city").IsRequired();
					parameters.Property(p => p.Sender).HasColumnName("sender").IsRequired();
					parameters.Property(p => p.Receiver).HasColumnName("receiver").IsRequired();
				});

			builder.Property(p => p.Created).HasColumnName("created");
			builder.Property(p => p.CreatedBy).HasColumnName("created_by");
			builder.Property(p => p.LastModified).HasColumnName("last_modified");
			builder.Property(p => p.LastModifiedBy).HasColumnName("last_modified_by");

			builder.HasOne(p => p.Shipment)
				   .WithMany(p => p.Packages);
		}
	}
}
