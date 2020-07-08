namespace AlgoLogistics.Application.DTO
{
	public class DeliveryDetailsDTO
	{
		public string Sender { get; set; }
		public string SenderEmail { get; set; }
		public string Receiver { get; set; }
		public string ReceiverEmail { get; set; }
		public string FromCity { get; set; }
		public string ToCity { get; set; }
	}
}
