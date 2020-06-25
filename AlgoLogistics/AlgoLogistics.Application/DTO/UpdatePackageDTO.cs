namespace AlgoLogistics.Application.DTO
{
	public class UpdatePackageDTO
	{
		public int PackageId { get; set; }
		public string Description { get; set; }
		public MoneyDTO Price { get; set; }
		public PhysicalParametersDTO PhysicalParameters { get; set; }
		public DeliveryDetailsDTO DeliveryDetails { get; set; }
	}
}
