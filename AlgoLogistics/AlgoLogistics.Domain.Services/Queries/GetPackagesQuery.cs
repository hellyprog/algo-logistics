using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace AlgoLogistics.Domain.Services.Queries
{
	public class GetPackagesQuery : IRequest<ExecutionResult<List<Package>>>
	{
	}
}
