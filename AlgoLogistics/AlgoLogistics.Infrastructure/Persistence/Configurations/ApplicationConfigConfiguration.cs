using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Infrastructure.Persistence.Configurations
{
	public class ApplicationConfigConfiguration : IEntityTypeConfiguration<ApplicationConfig>
	{
		public void Configure(EntityTypeBuilder<ApplicationConfig> builder)
		{
			builder.ToTable("ApplicationConfig");

			builder.HasKey(p => p.ApplicationConfigId);
			builder.Property(p => p.ApplicationConfigId).HasColumnName("application_config_id");
			builder.Property(p => p.ConfigName).HasColumnName("config_name");
			builder.Property(p => p.ConfigValue).HasColumnName("config_value");
		}
	}
}
