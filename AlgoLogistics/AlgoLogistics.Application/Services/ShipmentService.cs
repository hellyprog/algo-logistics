using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Services
{
	public class ShipmentService
	{
		private readonly IMediator _mediator;

		public ShipmentService(IMediator mediator)
		{
			_mediator = mediator;
		}
	}
}
