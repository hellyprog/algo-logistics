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
	public class ShipmentsQueryHandler : IRequestHandler<GetShipmentsQuery, ExecutionResult<List<Shipment>>>
	{
		private readonly IShipmentService _shipmentService;

		public ShipmentsQueryHandler(IShipmentService shipmentService)
		{
			_shipmentService = shipmentService;
		}

		public async Task<ExecutionResult<List<Shipment>>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
		{
			var result = await _shipmentService.GetShipmentsAsync(request);

			return result;
		}
	}
}
