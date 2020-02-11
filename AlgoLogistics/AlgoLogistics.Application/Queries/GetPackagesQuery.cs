using AlgoLogistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Queries
{
	public class GetPackagesQuery : IRequest<ICollection<Package>>
	{
	}
}
