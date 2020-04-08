using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.DTOs;
using AutoMapper;

namespace AlgoLogistics.Domain.Services.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<DeliveryDetailsDTO, DeliveryDetails>()
				.ConstructUsing(s => new DeliveryDetails(s.Sender, s.Receiver, s.FromCity, s.ToCity))
				.ReverseMap();

			CreateMap<PhysicalParametersDTO, PhysicalParameters>()
				.ConstructUsing(s => new PhysicalParameters(s.Width, s.Height, s.Length))
				.ReverseMap();
		}
	}
}
