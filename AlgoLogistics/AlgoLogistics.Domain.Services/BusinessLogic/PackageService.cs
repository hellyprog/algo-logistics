﻿using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.BusinessLogic
{
	public class PackageService : IPackageService
	{
		private readonly IApplicationDbContext _applicationDbContext;
		private readonly IPriceCalculator _priceCalculator;

		public PackageService(IApplicationDbContext applicationDbContext, IPriceCalculator priceCalculator)
		{
			_applicationDbContext = applicationDbContext;
			_priceCalculator = priceCalculator;
		}

		public async Task<ExecutionResult> CreatePackageAsync(CreatePackageCommand command, CancellationToken cancellationToken)
		{
			var deliveryDetails = command.DeliveryDetails;
			var physicalParameters = command.PhysicalParameters;
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

			var package = await Package.CreateAsync(command.Description, command.Price, physicalParameters, deliveryDetails, packageCategory, _priceCalculator);

			_applicationDbContext.Packages.Add(package);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Saving of package failed");
		}

		public async Task<ExecutionResult<List<Package>>> GetPackages(GetPackagesQuery query)
		{
			var packages = await _applicationDbContext.Packages.ToListAsync();

			return ExecutionResult<List<Package>>.CreateSuccessResult(packages);
		}

		public async Task<ExecutionResult<Package>> GetPackage(GetPackageQuery query)
		{
			var package = await _applicationDbContext.Packages.FirstOrDefaultAsync(p => p.InvoiceNo == query.InvoiceNo);

			return ExecutionResult<Package>.CreateSuccessResult(package);
		}
	}
}