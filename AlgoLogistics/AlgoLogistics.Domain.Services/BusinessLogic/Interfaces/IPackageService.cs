using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.BusinessLogic.Interfaces
{
	public interface IPackageService
	{
		Task<ExecutionResult> CreatePackageAsync(CreatePackageCommand command, CancellationToken cancellationToken);
		Task<ExecutionResult<Package>> GetPackageAsync(GetPackageQuery query);
		Task<ExecutionResult<List<Package>>> GetPackagesAsync(GetPackagesQuery query);
		Task<ExecutionResult> UpdatePackageAsync(UpdatePackageCommand request, CancellationToken cancellationToken);
		Task<ExecutionResult> DeletePackageAsync(DeletePackageCommand request, CancellationToken cancellationToken);
	}
}
