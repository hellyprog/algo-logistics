using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlgoLogistics.Infrastructure.Persistence.Configurations
{
	public class PackageConfiguration : IEntityTypeConfiguration<Package>
	{
		public void Configure(EntityTypeBuilder<Package> builder)
		{
			var deliveryStatusConverter = new EnumToStringConverter<PackageDeliveryStatus>();

			builder.ToTable("Packages");

			builder.HasKey(p => p.PackageId);
			builder.Property(p => p.PackageId).HasColumnName("package_id").IsRequired();
			builder.Property(p => p.InvoiceNo).HasColumnName("invoice_no").IsRequired();
			builder.Property(p => p.Description).HasColumnName("description").IsRequired();
			builder.OwnsOne(p => p.Price,
				parameter =>
				{
					parameter.Property(p => p.Amount).HasColumnName("price_amount").IsRequired();
					parameter.Property(p => p.Currency).HasColumnName("price_currency").IsRequired();
				});
			builder.OwnsOne(p => p.DeliveryPrice,
				parameter =>
				{
					parameter.Property(p => p.Amount).HasColumnName("delivery_price_amount").IsRequired();
					parameter.Property(p => p.Currency).HasColumnName("delivery_price_currency").IsRequired();
				});
			builder.Property(p => p.Status).HasColumnName("status").IsRequired().HasConversion(deliveryStatusConverter);
			builder.OwnsOne(p => p.PhysicalParameters,
				parameters =>
				{
					parameters.Property(p => p.Height).HasColumnName("height").IsRequired();
					parameters.Property(p => p.Length).HasColumnName("length").IsRequired();
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

			builder.HasOne(p => p.Transport)
				.WithMany(p => p.Packages);

			builder.HasOne(p => p.PackageCategory)
				.WithMany(p => p.Packages);
		}
	}
}
