using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Transport
	{
		private readonly List<Package> _packages;

		public int TransportId { get; private set; }
		public string TransportNo { get; private set; }
		public string TransportModel { get; private set; }
		public TransportType TransportType { get; private set; }
		public PhysicalParameters PhysicalParameters { get; private set; }
		public IEnumerable<Package> Packages => _packages;

		public Transport(string transportNo, string transportModel, TransportType transportType, PhysicalParameters physicalParameters)
		{
			this.TransportNo = transportNo ?? throw new ArgumentNullException(nameof(transportNo));
			this.TransportModel = transportModel ?? throw new ArgumentNullException(nameof(transportModel));
			this.TransportType = transportType;
			this.PhysicalParameters = physicalParameters ?? throw new ArgumentNullException(nameof(physicalParameters));
		}

		public Transport ClearTransport()
		{
			_packages.Clear();
			return this;
		}
	}
}
