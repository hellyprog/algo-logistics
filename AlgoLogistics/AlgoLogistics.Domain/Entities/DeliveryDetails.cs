using System;
using System.Globalization;

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
			var textInfo = new CultureInfo("en-US", false).TextInfo;

			Sender = textInfo.ToTitleCase(sender) ?? throw new ArgumentNullException(nameof(sender));
			Receiver = textInfo.ToTitleCase(receiver) ?? throw new ArgumentNullException(nameof(receiver));
			FromCity = textInfo.ToTitleCase(fromCity) ?? throw new ArgumentNullException(nameof(fromCity));
			ToCity = textInfo.ToTitleCase(toCity) ?? throw new ArgumentNullException(nameof(toCity));
		}
	}
}
