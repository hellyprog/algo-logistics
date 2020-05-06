using FluentValidation;

namespace AlgoLogistics.Application.DTO
{
	public class CreatePackageDTO
	{
		public string Description { get; set; }
		public MoneyDTO Price { get; set; }
		public PhysicalParametersDTO PhysicalParameters { get; set; }
		public DeliveryDetailsDTO DeliveryDetails { get; set; }
	}
}
