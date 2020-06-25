using AlgoLogistics.Application.DTO;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PackagesController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PackagesController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(typeof(ExecutionResult<List<Package>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetPackages()
		{
			var result = await _mediator.Send(new GetPackagesQuery());

			return StatusCode(StatusCodes.Status200OK, result);
		}

		[HttpGet("{invoiceNo}")]
		[ProducesResponseType(typeof(ExecutionResult<List<Package>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetPackage(string invoiceNo)
		{
			if (string.IsNullOrEmpty(invoiceNo))
			{
				return BadRequest(ExecutionResult<Package>.CreateFailureResult($"{nameof(invoiceNo)} cannot be null or empty"));
			}

			var result = await _mediator.Send(new GetPackageQuery { InvoiceNo = invoiceNo });
			var statusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreatePackage(CreatePackageDTO dto)
		{
			var command = _mapper.Map<CreatePackageCommand>(dto);
			var result = await _mediator.Send(command);
			var statusCode = result.Success ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}

		[HttpPut]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdatePackage(UpdatePackageDTO dto)
		{
			var command = _mapper.Map<UpdatePackageCommand>(dto);
			var result = await _mediator.Send(command);
			var statusCode = result.Success ? StatusCodes.Status204NoContent : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}

		[HttpDelete]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DeletePackage(int packageId)
		{
			var command = new DeletePackageCommand { PackageId = packageId };
			var result = await _mediator.Send(command);
			var statusCode = result.Success ? StatusCodes.Status204NoContent : StatusCodes.Status400BadRequest;

			return StatusCode(statusCode, result);
		}
	}
}