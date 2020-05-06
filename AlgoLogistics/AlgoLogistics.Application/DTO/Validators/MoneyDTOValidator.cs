using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.DTO.Validators
{
	public class MoneyDTOValidator : AbstractValidator<MoneyDTO>
	{
		public MoneyDTOValidator()
		{
			RuleFor(p => p.Amount).GreaterThan(0);
			RuleFor(p => p.Currency).NotNull();
		}
	}
}
