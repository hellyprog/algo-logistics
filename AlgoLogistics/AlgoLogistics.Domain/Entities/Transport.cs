using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Domain.Entities
{
	public class Transport
	{
		private List<Package> _packages;

		public int TransportId { get; private set; }
		public string TransportNo { get; private set; }
		public string TransportModel { get; private set; }
		public TransportType TransportType { get; private set; }
		public PhysicalParameters PhysicalParameters { get; private set; }
		public IEnumerable<Package> Packages => _packages ?? new List<Package>();
		public string CurrentCity { get; set; }

		private Transport()
		{
		}

		public Transport(string transportNo, string transportModel, TransportType transportType, PhysicalParameters physicalParameters, string currentCity)
		{
			TransportNo = transportNo ?? throw new ArgumentNullException(nameof(transportNo));
			TransportModel = transportModel ?? throw new ArgumentNullException(nameof(transportModel));
			TransportType = transportType;
			PhysicalParameters = physicalParameters ?? throw new ArgumentNullException(nameof(physicalParameters));
			CurrentCity = currentCity;
		}

		public Transport ClearTransport()
		{
			_packages?.Clear();
			return this;
		}

		public void AddPackage(Package package)
		{
			if (package != null)
			{
				if (_packages == null)
				{
					_packages = new List<Package>();
				}

				_packages.Add(package); 
			}
		}
	}
}
