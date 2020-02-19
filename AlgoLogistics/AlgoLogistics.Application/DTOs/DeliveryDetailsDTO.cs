using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.DTOs
{
	public class DeliveryDetailsDTO
	{
		public string Sender { get; set; }
		public string Receiver { get; set; }
		public string FromCity { get; set; }
		public string ToCity { get; set; }
	}
}
