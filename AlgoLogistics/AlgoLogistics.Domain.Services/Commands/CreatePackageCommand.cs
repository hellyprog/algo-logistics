using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class CreatePackageCommand : IRequest<ExecutionResult>
	{
		public string Description { get; set; }
		public decimal Price { get; set; }
		public PhysicalParameters PhysicalParameters { get; set; }
		public DeliveryDetails DeliveryDetails { get; set; }
	}
}
