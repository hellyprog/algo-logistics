using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.DTO.Validators
{
	public class CreatePackageDTOValidator : AbstractValidator<CreatePackageDTO>
	{
		public CreatePackageDTOValidator()
		{
			RuleFor(x => x.Description).NotNull();
		}
	}
}
