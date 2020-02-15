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
			var weightConverter = new EnumToStringConverter<WeightCategory>();
			var sizeConverter = new EnumToStringConverter<SizeCategory>();
			var deliveryStatusConverter = new EnumToStringConverter<DeliveryStatus>();

			builder.HasKey(p => p.PackageId);
			builder.Property(p => p.PackageId).HasColumnName("package_id");
			builder.Property(p => p.Description).HasColumnName("description").IsRequired();
			builder.Property(p => p.Price).HasColumnName("price").IsRequired();
			builder.Property(p => p.DeliveryPrice).HasColumnName("delivery_price").IsRequired();
			builder.Property(p => p.WeightCategory).HasColumnName("weight_category").IsRequired().HasConversion(weightConverter);
			builder.Property(p => p.SizeCategory).HasColumnName("size_category").IsRequired().HasConversion(sizeConverter);
			builder.Property(p => p.Status).HasColumnName("status").IsRequired().HasConversion(deliveryStatusConverter);
			builder.OwnsOne(p => p.PhysicalParameters,
				parameters =>
				{
					parameters.Property(p => p.Height).HasColumnName("height");
					parameters.Property(p => p.Length).HasColumnName("length");
					parameters.Property(p => p.Weight).HasColumnName("weight");
					parameters.Property(p => p.Width).HasColumnName("width");
				});
			builder.OwnsOne(p => p.DeliveryDetails,
				parameters =>
				{
					parameters.Property(p => p.FromCity).HasColumnName("from_city");
					parameters.Property(p => p.ToCity).HasColumnName("to_city");
					parameters.Property(p => p.Sender).HasColumnName("sender");
					parameters.Property(p => p.Receiver).HasColumnName("receiver");
				});
		}
	}
}
