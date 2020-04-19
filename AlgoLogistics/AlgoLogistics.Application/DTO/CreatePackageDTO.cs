namespace AlgoLogistics.Application.DTO
{
	public class CreatePackageDTO
	{
		public string Description { get; set; }
		public decimal Price { get; set; }
		public PhysicalParametersDTO PhysicalParameters { get; set; }
		public DeliveryDetailsDTO DeliveryDetails { get; set; }
	}
}
