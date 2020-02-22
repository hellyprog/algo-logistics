using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Queries
{
	public class GetShipmentsQuery : IRequest<ExecutionResult<List<Shipment>>>
	{
	}
}
