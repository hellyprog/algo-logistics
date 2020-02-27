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
	public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, ExecutionResult<List<Package>>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetPackagesQueryHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<ExecutionResult<List<Package>>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
		{
			var packages = await _applicationDbContext.Packages.ToListAsync();

			return ExecutionResult<List<Package>>.CreateSuccessResult(packages);
		}
	}
}
