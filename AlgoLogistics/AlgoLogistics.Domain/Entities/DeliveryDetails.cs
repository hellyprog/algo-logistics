using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class DeliveryDetails
	{
		public string Sender { get; private set; }
		public string Receiver { get; private set; }
		public string FromCity { get; private set; }
		public string ToCity { get; private set; }

		private DeliveryDetails() { }

		public DeliveryDetails(string sender, string receiver, string fromCity, string toCity)
		{
			CheckForNullsOrEmptyValues(sender, receiver, fromCity, toCity);

			Sender = sender;
			Receiver = receiver;
			FromCity = fromCity;
			ToCity = toCity;
		}

		private void CheckForNullsOrEmptyValues(string sender, string receiver, string fromCity, string toCity)
		{
			if (string.IsNullOrEmpty(sender))
			{
				throw new ArgumentException($"{nameof(sender)} cannot be null or empty", nameof(sender));
			}
			else if (string.IsNullOrEmpty(receiver))
			{
				throw new ArgumentException($"{nameof(receiver)} cannot be null or empty", nameof(receiver));
			}
			else if (string.IsNullOrEmpty(fromCity))
			{
				throw new ArgumentException($"{nameof(fromCity)} cannot be null or empty", nameof(fromCity));
			}
			else if (string.IsNullOrEmpty(toCity))
			{
				throw new ArgumentException($"{nameof(toCity)} cannot be null or empty", nameof(toCity));
			}
		}
	}
}
