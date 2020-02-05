using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Package : AuditableEntity
	{
		public int Id { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public decimal DeliveryPrice { get; private set; }
		public WeightCategory Weight { get; private set; }
		public SizeCategory Size { get; private set; }
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
			Weight = GetWeightCategory(physicalParameters.Weight);
			Size = GetSizeCategory(physicalParameters);
			Price = price;
			DeliveryPrice = CalculateDeliveryPrice(Size, Weight);

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
			var volume = measure.Height * measure.Length * measure.Width;

			if (volume > 0 && volume <= 0.01)
			{
				return SizeCategory.Small;
			}
			else if (volume > 0.01 && volume <= 0.07)
			{
				return SizeCategory.Medium;
			}
			else if (volume > 0.07 && volume <= 1)
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
			if (weight > 0 && weight <= 5)
			{
				return WeightCategory.Light;
			} 
			else if (weight > 5 && weight <= 15)
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
