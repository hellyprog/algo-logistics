using FluentValidation;
namespace AlgoLogistics.Application.DTO.Validators
{
	public class UpdatePackageDTOValidator : AbstractValidator<UpdatePackageDTO>
	{
		public UpdatePackageDTOValidator()
		{
			RuleFor(x => x.PackageId).NotEmpty().GreaterThan(0);
			RuleFor(x => x.Description).NotNull();
		}
	}
}
