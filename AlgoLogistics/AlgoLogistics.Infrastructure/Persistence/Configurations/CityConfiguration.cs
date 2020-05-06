using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoLogistics.Infrastructure.Persistence.Configurations
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.ToTable("Cities");

			builder.HasKey(x => x.CityId);
			builder.Property(p => p.CityId).HasColumnName("city_id").IsRequired();
			builder.Property(p => p.Name).HasColumnName("name").IsRequired();
			builder.Property(p => p.Country).HasColumnName("country").IsRequired();
			builder.Ignore(p => p.Connections);
		}
	}
}
