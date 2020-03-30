using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Interfaces
{
	public interface IPriceCalculator
	{
		Task<decimal> CalculateDeliveryPriceAsync();
	}
}
