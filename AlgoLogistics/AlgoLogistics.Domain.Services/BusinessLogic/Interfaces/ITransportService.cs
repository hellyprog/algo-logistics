using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Domain.Services.BusinessLogic.Interfaces
{
	public interface ITransportService
	{
		Task<ExecutionResult<List<DeliveryDetails>>> GetTransportShipmentEmails(string transportNo);
		Task<ExecutionResult> RegisterTransportDeparture(RegisterTransportDepartureCommand command, CancellationToken cancellationToken);
	}
}
