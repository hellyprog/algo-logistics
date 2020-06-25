using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;

namespace AlgoLogistics.Domain.Services.Commands
{
	public class DeletePackageCommand : IRequest<ExecutionResult>
	{
		public int PackageId { get; set; }
	}
}
