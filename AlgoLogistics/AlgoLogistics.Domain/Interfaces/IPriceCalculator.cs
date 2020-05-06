using AlgoLogistics.Domain.Entities;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Interfaces
{
	public interface IPriceCalculator
	{
		Task<Money> CalculateDeliveryPriceAsync(string fromCity, string toCity);
	}
}
