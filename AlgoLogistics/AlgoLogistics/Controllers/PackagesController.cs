using AlgoLogistics.Application.DTOs;
using AlgoLogistics.Application.Interfaces;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
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
		public async Task<IActionResult> GetPackage(string invoiceNo)
		{
			var result = await _packageService.GetPackageByInvoiceNoAsync(invoiceNo);

			return StatusCode(StatusCodes.Status200OK, result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreatePackage(CreatePackageDTO dto)
		{
			var result = await _packageService.CreatePackageAsync(dto);

			return result.Success
				? StatusCode(StatusCodes.Status201Created, result)
				: StatusCode(StatusCodes.Status400BadRequest, result);
		}
	}
}