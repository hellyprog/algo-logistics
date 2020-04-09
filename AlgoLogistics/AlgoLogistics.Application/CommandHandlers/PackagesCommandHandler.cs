using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.CommandHandlers
{
	public class PackagesCommandHandler : IRequestHandler<CreatePackageCommand, ExecutionResult>
	{
		private readonly IPackageService _packageService;

		public PackagesCommandHandler(IPackageService packageService)
		{
			_packageService = packageService;
		}

		public async Task<ExecutionResult> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
		{
			var executionResult = await _packageService.CreatePackageAsync(request, cancellationToken);

			return executionResult;
		}
	}
}
