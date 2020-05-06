using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Common.Exceptions;
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
		public Money Price { get; private set; }
		public Money DeliveryPrice { get; private set; }
		public PhysicalParameters PhysicalParameters { get; private set; }
		public DeliveryDetails DeliveryDetails { get; set; }
		public PackageCategory PackageCategory { get; set; }
		public PackageDeliveryStatus Status { get; private set; }
		public Shipment Shipment { get; private set; }

		private Package() { }

		private Package(
			string description,
			Money price,
			PhysicalParameters physicalParameters,
			DeliveryDetails deliveryDetails,
			PackageCategory packageCategory,
			Money deliveryPrice)
		{
			Description = !string.IsNullOrEmpty(description) 
				? description 
				: throw new AlgoLogisticsException($"{nameof(description)} cannot be null or empty");
			DeliveryDetails = deliveryDetails ?? throw new AlgoLogisticsException($"{nameof(deliveryDetails)} cannot be null");
			PhysicalParameters = physicalParameters ?? throw new AlgoLogisticsException($"{nameof(physicalParameters)} cannot be null");
			Price = price;
			DeliveryPrice = deliveryPrice;
			PackageCategory = packageCategory;
			Status = PackageDeliveryStatus.NotSent;
			InvoiceNo = GenerateInvoiceNo();
		}

		public static async Task<Package> CreateAsync(
			string description,
			Money price,
			PhysicalParameters physicalParameters,
			DeliveryDetails deliveryDetails,
			PackageCategory packageCategory,
			IPriceCalculator priceCalculator)
		{
			var deliveryPrice = await priceCalculator.CalculateDeliveryPriceAsync(deliveryDetails.FromCity, deliveryDetails.ToCity);
			return new Package(description, price, physicalParameters, deliveryDetails, packageCategory, deliveryPrice);
		}

		public void ProcessPackageToNextStatus()
		{
			Status = Status switch
			{
				PackageDeliveryStatus.NotSent => PackageDeliveryStatus.OnTheRoad,
				PackageDeliveryStatus.OnTheRoad => PackageDeliveryStatus.Arrived,
				PackageDeliveryStatus.Arrived => PackageDeliveryStatus.Received,
				PackageDeliveryStatus.Received => PackageDeliveryStatus.Received,
				_ => throw new AlgoLogisticsException($"Invalid emun value: {Status}")
			};
		}

		private string GenerateInvoiceNo()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
