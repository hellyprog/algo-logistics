using AlgoLogistics.Application.Common.Models;
using AlgoLogistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Commands
{
	public class CreatePackageCommand : IRequest<ExecutionResult>
	{
		public string Description { get; set; }
		public decimal Price { get; set; }
		public PhysicalParameters PhysicalParameters { get; set; }
		public DeliveryDetails DeliveryDetails { get; set; }
	}
}
