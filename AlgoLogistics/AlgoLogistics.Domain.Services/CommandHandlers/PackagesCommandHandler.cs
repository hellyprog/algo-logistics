﻿using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.CommandHandlers
{
	public class PackagesCommandHandler : IRequestHandler<CreatePackageCommand, ExecutionResult>
	{
		private readonly IApplicationDbContext _applicationDbContext;
		private readonly IMapper _mapper;
		private readonly IPriceCalculator _priceCalculator;

		public PackagesCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPriceCalculator priceCalculator)
		{
			_applicationDbContext = applicationDbContext;
			_mapper = mapper;
			_priceCalculator = priceCalculator;
		}

		public async Task<ExecutionResult> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
		{
			var deliveryDetails = _mapper.Map<DeliveryDetails>(request.DeliveryDetails);
			var physicalParameters = _mapper.Map<PhysicalParameters>(request.PhysicalParameters);

			var existingCities = await _applicationDbContext.Cities.Select(c => c.Name).ToListAsync();

			if (!existingCities.Contains(deliveryDetails.FromCity) || !existingCities.Contains(deliveryDetails.ToCity))
			{
				return ExecutionResult.CreateFailureResult("Our service doesn't work in provided city");
			}

			var packageCategories = await _applicationDbContext.PackageCategories.ToListAsync();
			var packageCategory = packageCategories
				.OrderBy(pc => (int)pc.SizeCategory)
				.FirstOrDefault(pc => pc.Length * pc.Width * pc.Height >= physicalParameters.Length * physicalParameters.Width * physicalParameters.Height);

			if (packageCategory == null)
			{
				return ExecutionResult.CreateFailureResult("Package size is out of limits");
			}

			var package = await Package.CreateAsync(request.Description, request.Price, physicalParameters, deliveryDetails, packageCategory, _priceCalculator);

			_applicationDbContext.Packages.Add(package);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Saving of package failed");
		}
	}
}
