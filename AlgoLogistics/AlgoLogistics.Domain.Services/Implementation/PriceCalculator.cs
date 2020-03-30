using AlgoLogistics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.Implementation
{
	public class PriceCalculator : IPriceCalculator
	{
		public async Task<decimal> CalculateDeliveryPriceAsync()
		{
			throw new NotImplementedException();
		}
	}
}
