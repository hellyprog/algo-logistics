using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Services.Queries
{
	public class GetShipmentsQuery : IRequest<ExecutionResult<List<Shipment>>>
	{
	}
}
