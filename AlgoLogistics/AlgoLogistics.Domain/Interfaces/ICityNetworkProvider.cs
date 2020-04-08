using AlgoLogistics.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Interfaces
{
	public interface ICityNetworkProvider
	{
		Task<List<City>> GetCityNetworkAsync();
	}
}
