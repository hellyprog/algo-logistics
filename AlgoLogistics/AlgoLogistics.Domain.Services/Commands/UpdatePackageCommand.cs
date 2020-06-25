using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class UpdatePackageCommand : IRequest<ExecutionResult>
	{
		public int PackageId { get; set; }
		public string Description { get; set; }
		public Money Price { get; set; }
		public PhysicalParameters PhysicalParameters { get; set; }
		public DeliveryDetails DeliveryDetails { get; set; }
	}
}
