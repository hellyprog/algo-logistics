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
	public class PackageCategoryConfiguration : IEntityTypeConfiguration<PackageCategory>
	{
		public void Configure(EntityTypeBuilder<PackageCategory> builder)
		{
			builder.ToTable("PackageCategories");

			builder.HasKey(k => k.PackageCategoryId);
			builder.Property(p => p.PackageCategoryId).HasColumnName("package_category_id").IsRequired();
			builder.Property(p => p.SizeCategory).IsRequired().HasColumnName("size_category").HasConversion(new EnumToStringConverter<SizeCategory>());
			builder.Property(p => p.Length).IsRequired().HasColumnName("length");
			builder.Property(p => p.Width).IsRequired().HasColumnName("width");
			builder.Property(p => p.Height).IsRequired().HasColumnName("height");
		}
	}
}
