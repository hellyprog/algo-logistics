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
		public WeightCategory Weight { get; private set; }
		public SizeCategory Size { get; private set; }
		public Measure Measure { get; private set; }
		public string Sender { get; private set; }
		public string Receiver { get; private set; }
		public string FromCity { get; private set; }
		public string ToCity { get; private set; }
		public DeliveryStatus Status { get; private set; }

		private Package() { }

		public Package(string description, Measure measure, double weight, string sender, string receiver, string fromCity, string toCity)
		{
			if (!IsValidInput(description, measure, weight, sender, receiver, fromCity, toCity, out ArgumentException exception))
			{
				throw exception;
			}

			Description = description;
			Sender = sender;
			Receiver = receiver;
			FromCity = fromCity;
			ToCity = toCity;
			Status = DeliveryStatus.NotSent;
			Weight = GetWeightCategory(weight);
			Size = GetSizeCategory(measure);
			Price = CalculatePrice();
		}

		private decimal CalculatePrice()
		{
			var price = 0.0m;

			return price;
		}

		private SizeCategory GetSizeCategory(Measure measure)
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
			else if (weight > 5 && weight <= 10)
			{
				return WeightCategory.Medium;
			}
			else
			{
				return WeightCategory.Heavy;
			}
		}

		private bool IsValidInput(string description, Measure measure, double weight, string sender, string receiver, string fromCity, string toCity, out ArgumentException exception)
		{
			bool result = false;
			exception = null;

			if (string.IsNullOrEmpty(description))
			{
				exception = new ArgumentException($"{nameof(description)} cannot be null or empty", nameof(description));
				return result;
			} 
			else if (measure == null)
			{
				exception = new ArgumentException($"{nameof(measure)} cannot be null", nameof(measure));
				return result;
			}
			else if (weight <= 0)
			{
				exception = new ArgumentException($"{nameof(weight)} should be greater than zero", nameof(weight));
				return result;
			}
			else if (string.IsNullOrEmpty(sender))
			{
				exception = new ArgumentException($"{nameof(sender)} cannot be null or empty", nameof(sender));
				return result;
			}
			else if (string.IsNullOrEmpty(receiver))
			{
				exception = new ArgumentException($"{nameof(receiver)} cannot be null or empty", nameof(receiver));
				return result;
			}
			else if (string.IsNullOrEmpty(fromCity))
			{
				exception = new ArgumentException($"{nameof(fromCity)} cannot be null or empty", nameof(fromCity));
				return result;
			}
			else if (string.IsNullOrEmpty(toCity))
			{
				exception = new ArgumentException($"{nameof(toCity)} cannot be null or empty", nameof(toCity));
				return result;
			}

			return true;
		}
	}
}
