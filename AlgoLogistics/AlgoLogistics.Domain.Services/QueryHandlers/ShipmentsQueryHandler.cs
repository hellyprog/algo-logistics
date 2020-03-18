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
	public class ShipmentsQueryHandler : IRequestHandler<GetShipmentsQuery, ExecutionResult<List<Shipment>>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public ShipmentsQueryHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<ExecutionResult<List<Shipment>>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
		{
			var shipments = await _applicationDbContext.Shipments.ToListAsync();

			return ExecutionResult<List<Shipment>>.CreateSuccessResult(shipments);
		}
	}
}
