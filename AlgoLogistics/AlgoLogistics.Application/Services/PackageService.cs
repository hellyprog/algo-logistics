﻿using AlgoLogistics.Application.Interfaces;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.Services
{
	public class PackageService : IPackageService
	{
		private readonly IMediator _mediator;

		public PackageService(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<ExecutionResult<List<Package>>> GetPackagesAsync()
		{
			var query = new GetPackagesQuery();
			var result = await _mediator.Send(query);

			return result;
		}

		public async Task<ExecutionResult> CreatePackageAsync(CreatePackageCommand command)
		{
			var result = await _mediator.Send(command);

			return result;
		}
	}
}