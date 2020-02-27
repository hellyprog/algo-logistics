using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class GenerateShipmentsCommand : IRequest<ExecutionResult>
	{
	}
}
