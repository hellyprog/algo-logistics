using AlgoLogistics.Application.DTOs;
using AlgoLogistics.Application.Interfaces;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Services
{
	public class PackageService : IPackageService
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PackageService(IMediator mediator, IMapper mapper)
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
