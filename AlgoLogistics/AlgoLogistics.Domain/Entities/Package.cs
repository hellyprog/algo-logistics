using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Enums;
using AlgoLogistics.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Entities
{
	public class Package : AuditableEntity
	{
		public int PackageId { get; private set; }
		public string InvoiceNo { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public decimal DeliveryPrice { get; private set; }
		public PhysicalParameters PhysicalParameters { get; private set; }
		public DeliveryDetails DeliveryDetails { get; set; }
		public PackageCategory PackageCategory { get; set; }
		public DeliveryStatus Status { get; private set; }
		public Shipment Shipment { get; private set; }

		private Package() { }

		private Package(
			string description,
			decimal price,
			PhysicalParameters physicalParameters,
			DeliveryDetails deliveryDetails,
			PackageCategory packageCategory,
			decimal deliveryPrice)
		{
			Description = !string.IsNullOrEmpty(description) ? description : throw new ArgumentNullException(nameof(description));
			DeliveryDetails = deliveryDetails ?? throw new ArgumentNullException(nameof(deliveryDetails));
			PhysicalParameters = physicalParameters ?? throw new ArgumentNullException(nameof(physicalParameters));
			Price = price > 0 ? price : throw new ArgumentException($"{nameof(price)} cannot be less than zero", nameof(price));
			DeliveryPrice = deliveryPrice;
			PackageCategory = packageCategory;
			Status = DeliveryStatus.NotSent;
			InvoiceNo = GenerateInvoiceNo();
		}

		public static async Task<Package> CreateAsync(
			string description,
			decimal price,
			PhysicalParameters physicalParameters,
			DeliveryDetails deliveryDetails,
			PackageCategory packageCategory,
			IPriceCalculator priceCalculator)
		{
			var deliveryPrice = await priceCalculator.CalculateDeliveryPriceAsync(deliveryDetails.FromCity, deliveryDetails.ToCity);
			return new Package(description, price, physicalParameters, deliveryDetails, packageCategory, deliveryPrice);
		}

		public void ProcessStatus()
		{
			Status = Status switch
			{
				DeliveryStatus.NotSent => DeliveryStatus.OnTheRoad,
				DeliveryStatus.OnTheRoad => DeliveryStatus.Arrived,
				DeliveryStatus.Arrived => DeliveryStatus.Received,
				DeliveryStatus.Received => DeliveryStatus.Received,
				_ => throw new ArgumentException(message: "Invalid emun value", nameof(Status))
			};
		}

		private string GenerateInvoiceNo()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
