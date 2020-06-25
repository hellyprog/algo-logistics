using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.CommandHandlers
{
	public class ShipmentsCommandHandler : IRequestHandler<GenerateShipmentsCommand, ExecutionResult>
	{
		private readonly IShipmentService _shipmentService;

		public ShipmentsCommandHandler(IShipmentService shipmentService)
		{
			_shipmentService = shipmentService;
		}

		public async Task<ExecutionResult> Handle(GenerateShipmentsCommand request, CancellationToken cancellationToken)
		{
			var shipmentGenerationResult = await _shipmentService.GenerateShipments(request, cancellationToken);

			if (shipmentGenerationResult.Success)
			{
				var carAssigningExecutionResult = await _shipmentService.AssignCarsToShipmentsAsync();
			}

			return default;
		}
	}
}
