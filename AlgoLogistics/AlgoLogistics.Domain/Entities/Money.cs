using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Money
	{
		public Money(decimal amount, string currency)
		{
			Amount = amount;
			Currency = currency ?? throw new ArgumentNullException(nameof(currency));
		}

		public decimal Amount { get; set; }
		public string Currency { get; set; }
	}
}
