using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Package : AuditableEntity
	{
		public int PackageId { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public decimal DeliveryPrice { get; private set; }
		public WeightCategory WeightCategory { get; private set; }
		public SizeCategory SizeCategory { get; private set; }
		public PhysicalParameters PhysicalParameters { get; private set; }
		public DeliveryDetails DeliveryDetails { get; set; }
		public DeliveryStatus Status { get; private set; }

		private Package() { }

		public Package(string description, decimal price, PhysicalParameters physicalParameters, DeliveryDetails deliveryDetails, string createdBy)
		{
			ValidateInput(description, price, physicalParameters, deliveryDetails);

			Description = description;
			DeliveryDetails = deliveryDetails;
			Status = DeliveryStatus.NotSent;
			WeightCategory = GetWeightCategory(physicalParameters.Weight);
			SizeCategory = GetSizeCategory(physicalParameters);
			Price = price;
			DeliveryPrice = CalculateDeliveryPrice(SizeCategory, WeightCategory);

			Created = DateTime.UtcNow;
			CreatedBy = createdBy;
		}

		private decimal CalculateDeliveryPrice(SizeCategory sizeCategory, WeightCategory weight)
		{
			var price = (decimal)sizeCategory + (decimal)weight;

			return price;
		}

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

		private void ValidateInput(string description, decimal price, PhysicalParameters physicalParameters, DeliveryDetails deliveryDetails)
		{
			if (string.IsNullOrEmpty(description))
			{
				throw new ArgumentException($"{nameof(description)} cannot be null or empty", nameof(description));
			} 
			else if (price <= 0)
			{
				throw new ArgumentException($"{nameof(price)} cannot be null or empty", nameof(price));
			}
			else if (physicalParameters == null)
			{
				throw new ArgumentException($"{nameof(physicalParameters)} cannot be null", nameof(physicalParameters));
			}
			else if (deliveryDetails == null)
			{
				throw new ArgumentException($"{nameof(deliveryDetails)} cannot be null", nameof(deliveryDetails));
			}
		}
	}
}
