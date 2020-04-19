using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.DTO.Validators
{
	public class PhysicalParametersDTOValidator : AbstractValidator<PhysicalParametersDTO>
	{
		public PhysicalParametersDTOValidator()
		{
			RuleFor(x => x.Height).GreaterThan(0);
			RuleFor(x => x.Width).GreaterThan(0);
			RuleFor(x => x.Length).GreaterThan(0);
		}
	}
}
