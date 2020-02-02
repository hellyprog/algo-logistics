using AlgoLogistics.Domain.Common;
using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Package : AuditableEntity
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public WeightCategory Weight { get; set; }
		public SizeCategory Size { get; set; }
		public string Sender { get; set; }
		public string Reciever { get; set; }
		public string FromCity { get; set; }
		public string ToCity { get; set; }
		public DeliveryStatus Status { get; set; }
	}
}
