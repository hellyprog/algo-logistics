using AlgoLogistics.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLogistics.Domain.Services.Commands.Validators
{
	public class CreatePackageValidator : AbstractValidator<CreatePackageCommand>
	{
		public CreatePackageValidator(IApplicationDbContext dbContext)
		{
			var biggestPackageCategory = dbContext.PackageCategories.FirstOrDefault(pc => pc.SizeCategory == Enums.SizeCategory.ExtraLarge);

			var limitLength = biggestPackageCategory.Length;
			var limitWidth = biggestPackageCategory.Width;
			var limitHeight = biggestPackageCategory.Height;

			RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
			RuleFor(x => x.Description).NotNull().NotEmpty();
			RuleFor(x => x.DeliveryDetails).NotNull();
			RuleFor(x => x.DeliveryDetails.FromCity).NotNull();
			RuleFor(x => x.DeliveryDetails.ToCity).NotNull();
			RuleFor(x => x.DeliveryDetails.Sender).NotNull();
			RuleFor(x => x.DeliveryDetails.Receiver).NotNull();
			RuleFor(x => x.PhysicalParameters).NotNull();
			RuleFor(x => x.PhysicalParameters.Length).NotNull().GreaterThan(0).LessThanOrEqualTo(limitLength);
			RuleFor(x => x.PhysicalParameters.Width).NotNull().GreaterThan(0).LessThanOrEqualTo(limitWidth);
			RuleFor(x => x.PhysicalParameters.Height).NotNull().GreaterThan(0).LessThanOrEqualTo(limitHeight);
		}
	}
}
