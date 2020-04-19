using AlgoLogistics.Application.DTO;
using AlgoLogistics.Application.DTO.Validators;
using AlgoLogistics.Application.Executors.Interfaces;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Executors
{
	public class PackageLogicExecutor : IPackageLogicExecutor
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PackageLogicExecutor(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		public async Task<ExecutionResult> CreatePackageAsync(CreatePackageDTO dto)
		{
			var command = _mapper.Map<CreatePackageCommand>(dto);
			var result = await _mediator.Send(command);

			return result;
		}

		public async Task<ExecutionResult<Package>> GetPackageByInvoiceNoAsync(string invoiceNo)
		{
			if (string.IsNullOrEmpty(invoiceNo))
			{
				return ExecutionResult<Package>.CreateFailureResult($"{nameof(invoiceNo)} cannot be null or empty");
			}

			var result = await _mediator.Send(new GetPackageQuery { InvoiceNo = invoiceNo });

			return result;
		}

		public async Task<ExecutionResult<List<Package>>> GetPackagesAsync()
		{
			var result = await _mediator.Send(new GetPackagesQuery());

			return result;
		}
	}
}
