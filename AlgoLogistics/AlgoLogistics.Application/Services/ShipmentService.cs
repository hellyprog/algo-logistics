using AlgoLogistics.Application.Interfaces;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
			var command = new GenerateShipmentsCommand();
			var result = await _mediator.Send(command);

			return result;
		}

		public async Task<ExecutionResult<List<Shipment>>> GetShipmentsAsync()
		{
			var query = new GetShipmentsQuery();
			var result = await _mediator.Send(query);

			return result;
		}
	}
}
