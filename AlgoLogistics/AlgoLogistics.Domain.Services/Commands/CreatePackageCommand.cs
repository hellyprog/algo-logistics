using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Domain.Services.DTOs;
using AlgoLogistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class CreatePackageCommand : IRequest<ExecutionResult>
	{
		public string Description { get; set; }
		public decimal Price { get; set; }
		public PhysicalParametersDTO PhysicalParameters { get; set; }
		public DeliveryDetailsDTO DeliveryDetails { get; set; }
	}
}
