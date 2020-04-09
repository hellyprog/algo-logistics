using AlgoLogistics.Application.DTOs;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Executors.Interfaces
{
	public interface IPackageLogicExecutor
	{
		Task<ExecutionResult> CreatePackageAsync(CreatePackageDTO command);
		Task<ExecutionResult<Package>> GetPackageByInvoiceNoAsync(string invoiceNo);
		Task<ExecutionResult<List<Package>>> GetPackagesAsync();
	}
}
