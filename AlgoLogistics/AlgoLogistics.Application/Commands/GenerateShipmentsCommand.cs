using AlgoLogistics.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Commands
{
	public class GenerateShipmentsCommand : IRequest<ExecutionResult>
	{
	}
}
