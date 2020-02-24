﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoLogistics.Application.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgoLogistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : BaseAlgoLogisticsController
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IMediator mediator, IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetShipments()
        {
            var result = await _shipmentService.GetShipmentsAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateShipments()
        {
            var result = await _shipmentService.GenerateShipmentsAsync();

            return result.Success
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status400BadRequest, result);
        }
    }
}