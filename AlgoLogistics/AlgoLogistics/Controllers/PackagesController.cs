using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Application.Queries;
using AlgoLogistics.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgoLogistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PackagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ExecutionResult<List<Package>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPackages()
        {
            var query = new GetPackagesQuery();
            var result = await _mediator.Send(query);

            return result.Success
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}