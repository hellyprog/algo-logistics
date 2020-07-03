using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipmentsController : BaseAlgoLogisticsController
	{
		private readonly IMediator _mediator;

		public ShipmentsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(typeof(ExecutionResult<List<Shipment>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetShipments()
		{
			var result = await _mediator.Send(new GetShipmentsQuery());
			var statusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GenerateShipments(GenerateShipmentsCommand command)
		{
			var result = await _mediator.Send(command);
			var statusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}

		[HttpDelete("{shipmentId}")]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DeleteShipment(int shipmentId)
		{
			var command = new DeleteShipmentCommand { ShipmentId = shipmentId };
			var result = await _mediator.Send(command);
			var statusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}
	}
}