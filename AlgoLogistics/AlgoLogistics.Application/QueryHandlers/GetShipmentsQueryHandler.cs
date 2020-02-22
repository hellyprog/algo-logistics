using AlgoLogistics.Application.Common.Interfaces;
using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Application.Queries;
using AlgoLogistics.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.QueryHandlers
{
	public class GetShipmentsQueryHandler : IRequestHandler<GetShipmentsQuery, ExecutionResult<List<Shipment>>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetShipmentsQueryHandler(IApplicationDbContext applicationDbContext)
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
