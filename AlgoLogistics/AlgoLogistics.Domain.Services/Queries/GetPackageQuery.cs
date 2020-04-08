using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Common.Models;
using MediatR;

namespace AlgoLogistics.Domain.Services.Queries
{
	public class GetPackageQuery : IRequest<ExecutionResult<Package>>
	{
		public string InvoiceNo { get; set; }
	}
}
