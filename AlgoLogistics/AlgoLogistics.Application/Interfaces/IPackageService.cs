using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Interfaces
{
	public interface IPackageService
	{
		Task<ExecutionResult> CreatePackageAsync(CreatePackageCommand command);
		Task<ExecutionResult<Package>> GetPackageByInvoiceNoAsync(string invoiceNo);
		Task<ExecutionResult<List<Package>>> GetPackagesAsync();
	}
}
