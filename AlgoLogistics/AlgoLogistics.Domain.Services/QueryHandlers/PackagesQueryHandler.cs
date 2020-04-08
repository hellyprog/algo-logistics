using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.QueryHandlers
{
	public class PackagesQueryHandler :
		IRequestHandler<GetPackagesQuery, ExecutionResult<List<Package>>>,
		IRequestHandler<GetPackageQuery, ExecutionResult<Package>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public PackagesQueryHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<ExecutionResult<List<Package>>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
		{
			var packages = await _applicationDbContext.Packages.ToListAsync();

			return ExecutionResult<List<Package>>.CreateSuccessResult(packages);
		}

		public async Task<ExecutionResult<Package>> Handle(GetPackageQuery request, CancellationToken cancellationToken)
		{
			var package = await _applicationDbContext.Packages.FirstOrDefaultAsync(p => p.InvoiceNo == request.InvoiceNo);

			return ExecutionResult<Package>.CreateSuccessResult(package);
		}
	}
}
