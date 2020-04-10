﻿using AlgoLogistics.Domain.Common.Exceptions;
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

			Sender = !string.IsNullOrEmpty(sender) 
				? textInfo.ToTitleCase(sender) 
				: throw new AlgoLogisticsException($"{nameof(sender)} cannot be null or empty");
			Receiver = !string.IsNullOrEmpty(receiver) 
				? textInfo.ToTitleCase(receiver) 
				: throw new AlgoLogisticsException($"{nameof(receiver)} cannot be null or empty");
			FromCity = !string.IsNullOrEmpty(fromCity) 
				? textInfo.ToTitleCase(fromCity) 
				: throw new AlgoLogisticsException($"{nameof(fromCity)} cannot be null or empty");
			ToCity = !string.IsNullOrEmpty(ToCity) 
				? textInfo.ToTitleCase(toCity) 
				: throw new AlgoLogisticsException($"{nameof(ToCity)} cannot be null or empty");
		}
	}
}
