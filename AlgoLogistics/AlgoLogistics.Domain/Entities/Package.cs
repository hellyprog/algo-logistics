using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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
		public WeightCategory WeightCategory => GetWeightCategory(PhysicalParameters.Weight);
		public SizeCategory SizeCategory => GetSizeCategory(PhysicalParameters);
		public DeliveryStatus Status { get; private set; }
		public Shipment Shipment { get; private set; }

		private Package() { }

		public Package(string description, decimal price, PhysicalParameters physicalParameters, DeliveryDetails deliveryDetails)
		{
			Description = description ?? throw new ArgumentNullException(nameof(description));
			DeliveryDetails = deliveryDetails ?? throw new ArgumentNullException(nameof(deliveryDetails));
			PhysicalParameters = physicalParameters ?? throw new ArgumentNullException(nameof(physicalParameters));
			Price = price > 0 ? price : throw new ArgumentException($"{nameof(price)} cannot be less than zero", nameof(price));

			Status = DeliveryStatus.NotSent;
			DeliveryPrice = CalculateDeliveryPrice(SizeCategory, WeightCategory);
			InvoiceNo = GenerateInvoiceNo();
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
			var currentTime = DateTime.Now.ToString();
			var algorithm = SHA256.Create();
			var invoiceNoBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(currentTime));
			
			var sb = new StringBuilder();
			foreach (byte b in invoiceNoBytes)
			{
				sb.Append(b.ToString("X2"));
			}

			return sb.ToString();
		}

		private decimal CalculateDeliveryPrice(SizeCategory sizeCategory, WeightCategory weight) => (decimal)sizeCategory + (decimal)weight;

		private SizeCategory GetSizeCategory(PhysicalParameters measure)
		{
			const double SmallLimit = 0.2;
			const double MediumLimit = 0.5;
			const double LargeLimit = 1;

			if (measure.Height <= SmallLimit && measure.Length <= SmallLimit && measure.Width <= SmallLimit)
			{
				return SizeCategory.Small;
			}
			else if (measure.Height <= MediumLimit && measure.Length <= MediumLimit && measure.Width <= MediumLimit)
			{
				return SizeCategory.Medium;
			}
			else if (measure.Height <= LargeLimit && measure.Length <= LargeLimit && measure.Width <= LargeLimit)
			{
				return SizeCategory.Large;
			}
			else
			{
				return SizeCategory.ExtraLarge;
			}
		}

		private WeightCategory GetWeightCategory(double weight)
		{
			const double LightLimit = 5;
			const double MediumLimit = 15;

			if (weight <= LightLimit)
			{
				return WeightCategory.Light;
			} 
			else if (weight <= MediumLimit)
			{
				return WeightCategory.Medium;
			}
			else
			{
				return WeightCategory.Heavy;
			}
		}
	}
}
