using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Money
	{
		public Money(decimal amount, string currency)
		{
			this.Amount = amount;
			this.Currency = currency;
		}

		public decimal Amount { get; set; }
		public string Currency { get; set; }
	}
}
