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
			this.Sender = sender ?? throw new ArgumentNullException(nameof(sender));
			this.Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
			this.FromCity = fromCity ?? throw new ArgumentNullException(nameof(fromCity));
			this.ToCity = toCity ?? throw new ArgumentNullException(nameof(toCity));
		}
	}
}
