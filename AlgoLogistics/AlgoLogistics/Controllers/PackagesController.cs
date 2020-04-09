using AlgoLogistics.Application.DTOs;
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
	public class PackagesController : ControllerBase
	{
		private readonly IPackageLogicExecutor _packageLogicExecutor;

		public PackagesController(IPackageLogicExecutor packageLogicExecutor)
		{
			_packageLogicExecutor = packageLogicExecutor;
		}

		[HttpGet]
		[ProducesResponseType(typeof(ExecutionResult<List<Package>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetPackages()
		{
			var result = await _packageLogicExecutor.GetPackagesAsync();

			return StatusCode(StatusCodes.Status200OK, result);
		}

		[HttpGet("{invoiceNo}")]
		[ProducesResponseType(typeof(ExecutionResult<List<Package>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetPackage(string invoiceNo)
		{
			var result = await _packageLogicExecutor.GetPackageByInvoiceNoAsync(invoiceNo);

			return StatusCode(StatusCodes.Status200OK, result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(ExecutionResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreatePackage(CreatePackageDTO dto)
		{
			var result = await _packageLogicExecutor.CreatePackageAsync(dto);

			return result.Success
				? StatusCode(StatusCodes.Status201Created, result)
				: StatusCode(StatusCodes.Status400BadRequest, result);
		}
	}
}