﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoLogistics.Application.Commands;
using AlgoLogistics.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgoLogistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : BaseAlgoLogisticsController
    {
        private readonly IMediator _mediator;

        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> GenerateShipments()
        {
            var command = new GenerateShipmentsCommand();
            var result = await _mediator.Send(command);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}