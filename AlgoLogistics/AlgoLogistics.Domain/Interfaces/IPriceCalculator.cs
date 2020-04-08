using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Interfaces
{
	public interface IPriceCalculator
	{
		Task<decimal> CalculateDeliveryPriceAsync(string fromCity, string toCity);
	}
}
