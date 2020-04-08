using AlgoLogistics.Application.Interfaces;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Services
{
	public class ShipmentService : IShipmentService
	{
		private readonly IMediator _mediator;

		public ShipmentService(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<ExecutionResult> GenerateShipmentsAsync()
		{
			var result = await _mediator.Send(new GenerateShipmentsCommand());

			return result;
		}

		public async Task<ExecutionResult<List<Shipment>>> GetShipmentsAsync()
		{
			var result = await _mediator.Send(new GetShipmentsQuery());

			return result;
		}
	}
}
