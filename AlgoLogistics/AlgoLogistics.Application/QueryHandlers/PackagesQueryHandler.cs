using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.QueryHandlers
{
	public class PackagesQueryHandler :
		IRequestHandler<GetPackagesQuery, ExecutionResult<List<Package>>>,
		IRequestHandler<GetPackageQuery, ExecutionResult<Package>>
	{
		private readonly IPackageService _packageService;

		public PackagesQueryHandler(IPackageService packageService)
		{
			_packageService = packageService;
		}

		public async Task<ExecutionResult<List<Package>>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
		{
			var result = await _packageService.GetPackages(request);

			return result;
		}

		public async Task<ExecutionResult<Package>> Handle(GetPackageQuery request, CancellationToken cancellationToken)
		{
			var result = await _packageService.GetPackage(request);

			return result;
		}
	}
}
