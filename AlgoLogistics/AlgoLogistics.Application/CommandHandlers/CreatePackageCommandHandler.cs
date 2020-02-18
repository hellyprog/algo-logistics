using AlgoLogistics.Application.Commands;
using AlgoLogistics.Application.Common.Interfaces;
using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.CommandHandlers
{
	public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, ExecutionResult>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public CreatePackageCommandHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<ExecutionResult> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
		{
			var package = new Package(request.Description, request.Price, request.PhysicalParameters, request.DeliveryDetails);

			_applicationDbContext.Packages.Add(package);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Saving of package failed");
		}
	}
}
