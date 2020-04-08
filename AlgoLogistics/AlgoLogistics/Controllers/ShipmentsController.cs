using AlgoLogistics.Application.Interfaces;
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
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ExecutionResult<List<Shipment>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShipments()
        {
            var result = await _shipmentService.GetShipmentsAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateShipments()
        {
            var result = await _shipmentService.GenerateShipmentsAsync();

            return result.Success
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status400BadRequest, result);
        }
    }
}