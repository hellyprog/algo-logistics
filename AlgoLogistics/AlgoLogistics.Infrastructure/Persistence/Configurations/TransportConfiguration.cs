using AlgoLogistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlgoLogistics.Infrastructure.Persistence.Configurations
{
	public class TransportConfiguration : IEntityTypeConfiguration<Transport>
	{
		public void Configure(EntityTypeBuilder<Transport> builder)
		{
			var transportTypeConverter = new EnumToStringConverter<TransportType>();

			builder.ToTable("Transports");

			builder.HasKey(p => p.TransportId);
			builder.Property(p => p.TransportId).HasColumnName("transport_id").IsRequired();
			builder.Property(p => p.TransportModel).HasColumnName("transport_model").IsRequired();
			builder.Property(p => p.TransportNo).HasColumnName("transport_no").IsRequired();
			builder.Property(p => p.TransportType).HasColumnName("transport_type").IsRequired().HasConversion(transportTypeConverter);
			builder.OwnsOne(p => p.PhysicalParameters,
				parameters =>
				{
					parameters.Property(p => p.Height).HasColumnName("height").IsRequired();
					parameters.Property(p => p.Length).HasColumnName("length").IsRequired();
					parameters.Property(p => p.Width).HasColumnName("width").IsRequired();
				});
			builder.HasMany(p => p.Packages)
				   .WithOne(p => p.Transport)
				   .OnDelete(DeleteBehavior.SetNull)
				   .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}
