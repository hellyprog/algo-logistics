using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using AlgoLogistics.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgoLogistics.Application.Interfaces;

namespace AlgoLogistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ExecutionResult<List<Package>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPackages()
        {
            var result = await _packageService.GetPackagesAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{invoiceNo}")]
        [ProducesResponseType(typeof(ExecutionResult<List<Package>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPackages(string invoiceNo)
        {
            var result = await _packageService.GetPackageByInvoiceNoAsync(invoiceNo);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePackage(CreatePackageCommand command)
        {
            var result = await _packageService.CreatePackageAsync(command);

            return result.Success 
                ? StatusCode(StatusCodes.Status201Created, result)
                : StatusCode(StatusCodes.Status400BadRequest, result);
        }
    }
}