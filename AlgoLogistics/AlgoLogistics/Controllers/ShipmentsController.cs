using AlgoLogistics.Application.Executors.Interfaces;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipmentsController : BaseAlgoLogisticsController
	{
		private readonly IShipmentLogicExecutor _shipmentLogicExecutor;

		public ShipmentsController(IShipmentLogicExecutor shipmentLogicExecutor)
		{
			_shipmentLogicExecutor = shipmentLogicExecutor;
		}

		[HttpGet]
		[ProducesResponseType(typeof(ExecutionResult<List<Shipment>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetShipments()
		{
			var result = await _shipmentLogicExecutor.GetShipmentsAsync();
			var statusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GenerateShipments()
		{
			var result = await _shipmentLogicExecutor.GenerateShipmentsAsync();
			var statusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}
	}
}