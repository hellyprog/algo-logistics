using AlgoLogistics.Application.Common.Interfaces;
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
	public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, List<Package>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetPackagesQueryHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public Task<List<Package>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
		{
			var packages = _applicationDbContext.Packages.ToListAsync();

			return packages;
		}
	}
}
