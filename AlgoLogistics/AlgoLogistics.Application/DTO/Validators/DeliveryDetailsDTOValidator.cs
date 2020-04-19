using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.DTO.Validators
{
	public class DeliveryDetailsDTOValidator : AbstractValidator<DeliveryDetailsDTO>
	{
		public DeliveryDetailsDTOValidator()
		{
			RuleFor(x => x.FromCity).NotNull();
			RuleFor(x => x.ToCity).NotNull();
			RuleFor(x => x.Sender).NotNull();
			RuleFor(x => x.Receiver).NotNull();
		}
	}
}
