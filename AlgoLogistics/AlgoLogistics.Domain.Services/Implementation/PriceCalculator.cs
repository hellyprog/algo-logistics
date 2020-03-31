using AlgoLogistics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.Implementation
{
	public class PriceCalculator : IPriceCalculator
	{
		public Task<decimal> CalculateDeliveryPriceAsync()
		{
			return Task.FromResult(40m);
		}
	}
}
