using AlgoLogistics.Application.Queries;
using AlgoLogistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.QueryHandlers
{
	public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, ICollection<Package>>
	{
		public Task<ICollection<Package>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
		{
			ICollection<Package> packages = new List<Package>();
			return Task.FromResult(packages);
		}
	}
}
