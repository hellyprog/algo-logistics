using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.CommandHandlers
{
	public class PackagesCommandHandler : IRequestHandler<CreatePackageCommand, ExecutionResult>
	{
		private readonly IApplicationDbContext _applicationDbContext;
		private readonly IMapper _mapper;

		public PackagesCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
		{
			_applicationDbContext = applicationDbContext;
			_mapper = mapper;
		}

		public async Task<ExecutionResult> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
		{
			var deliveryDetails = _mapper.Map<DeliveryDetails>(request.DeliveryDetails);
			var physicalParameters = _mapper.Map<PhysicalParameters>(request.PhysicalParameters);
			var package = new Package(request.Description, request.Price, physicalParameters, deliveryDetails);

			_applicationDbContext.Packages.Add(package);
			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Saving of package failed");
		}
	}
}
