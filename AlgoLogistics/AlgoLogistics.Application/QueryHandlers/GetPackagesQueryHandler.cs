using AlgoLogistics.Application.Common.Interfaces;
using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Application.Queries;
using AlgoLogistics.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.QueryHandlers
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
