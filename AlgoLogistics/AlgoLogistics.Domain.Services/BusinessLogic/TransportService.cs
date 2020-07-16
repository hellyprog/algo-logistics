using AlgoLogistics.DataAccess;
using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using AlgoLogistics.Domain.Entities;

namespace AlgoLogistics.Domain.Services.BusinessLogic
{
	public class TransportService : ITransportService
	{
		protected readonly IApplicationDbContext _applicationDbContext;

		public TransportService(
			IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<ExecutionResult<List<DeliveryDetails>>> GetTransportShipmentEmails(string transportNo)
		{
			var transport = await _applicationDbContext.Transports
				.Include(t => t.Packages)
				.FirstOrDefaultAsync(t => t.TransportNo == transportNo && t.Packages.All(p => p.Status == Enums.PackageDeliveryStatus.OnTheRoad));

			var result = transport.Packages.Select(p => p.DeliveryDetails).ToList();

			return ExecutionResult<List<DeliveryDetails>>.CreateSuccessResult(result);
		}

		public async Task<ExecutionResult> RegisterTransportArrival(RegisterTransportArrivalCommand command, CancellationToken cancellationToken)
		{
			var transport = await _applicationDbContext.Transports
				.Include(t => t.Packages)
					.ThenInclude(p => p.Shipment)
				.FirstOrDefaultAsync(t => t.TransportNo == command.TransportNo && t.Packages.All(p => p.Status == Enums.PackageDeliveryStatus.OnTheRoad));

			var shipment = transport.Packages.FirstOrDefault()?.Shipment;

			transport.Arrive();

			if (!transport.Packages.Select(p => p.Transport).Any())
			{
				shipment.ChangeStatus();
			}

			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Transport arrival failed");
		}

		public async Task<ExecutionResult> RegisterTransportDeparture(RegisterTransportDepartureCommand command, CancellationToken cancellationToken)
		{
			var transport = await _applicationDbContext.Transports
				.Include(t => t.Packages)
					.ThenInclude(p => p.Shipment)
				.FirstOrDefaultAsync(t => t.TransportNo == command.TransportNo && t.Packages.All(p => p.Status == Enums.PackageDeliveryStatus.ShipmentCreated));

			transport.Depart();

			var savingResult = await _applicationDbContext.SaveChangesAsync(cancellationToken);

			return savingResult > 0
				? ExecutionResult.CreateSuccessResult()
				: ExecutionResult.CreateFailureResult("Transport departure failed");
		}
	}
}
