using AlgoLogistics.Domain.Services;
using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.CommandHandlers
{
	public class ShipmentsCommandHandler :
		IRequestHandler<GenerateShipmentsCommand, ExecutionResult>,
		IRequestHandler<DeleteShipmentCommand, ExecutionResult>
	{
		private readonly IShipmentService _shipmentService;

		public ShipmentsCommandHandler(IShipmentService shipmentService)
		{
			_shipmentService = shipmentService;
		}

		public async Task<ExecutionResult> Handle(GenerateShipmentsCommand request, CancellationToken cancellationToken)
		{
			//state machine?
			var shipmentGenerationResult = await _shipmentService.GenerateShipmentsAsync(request, cancellationToken);

			if (shipmentGenerationResult.Success)
			{
				var carAssigningExecutionResult = await _shipmentService.AssignShipmentsToTransportAsync(request, cancellationToken);

				if (carAssigningExecutionResult.Success)
				{
					var packageDeassignmentExecutionResult = await _shipmentService.DeassignPackagesWithoutTransportAsync(request, cancellationToken);

					return packageDeassignmentExecutionResult;
				}

				return carAssigningExecutionResult;
			}

			return shipmentGenerationResult;
		}

		public async Task<ExecutionResult> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
		{
			var executionResult = await _shipmentService.DeleteShipmentAsync(request, cancellationToken);

			return executionResult;
		}
	}
}
