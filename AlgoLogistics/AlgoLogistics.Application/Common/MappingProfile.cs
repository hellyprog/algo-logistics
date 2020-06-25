using AlgoLogistics.Application.DTO;
using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.Commands;
using AutoMapper;

namespace AlgoLogistics.Application.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreatePackageDTO, CreatePackageCommand>()
				.ForMember(s => s.Price, x => x.MapFrom(d => new Money(d.Price.Amount, d.Price.Currency)))
				.ForMember(s => s.PhysicalParameters,
					x => x.MapFrom(d => new PhysicalParameters(d.PhysicalParameters.Length, d.PhysicalParameters.Width, d.PhysicalParameters.Height)))
				.ForMember(s => s.DeliveryDetails,
					x => x.MapFrom(d => new DeliveryDetails(d.DeliveryDetails.Sender, d.DeliveryDetails.Receiver, d.DeliveryDetails.FromCity, d.DeliveryDetails.ToCity)));

			CreateMap<UpdatePackageDTO, UpdatePackageCommand>()
				.ForMember(s => s.Price, x => x.MapFrom(d => new Money(d.Price.Amount, d.Price.Currency)))
				.ForMember(s => s.PhysicalParameters,
					x => x.MapFrom(d => new PhysicalParameters(d.PhysicalParameters.Length, d.PhysicalParameters.Width, d.PhysicalParameters.Height)))
				.ForMember(s => s.DeliveryDetails,
					x => x.MapFrom(d => new DeliveryDetails(d.DeliveryDetails.Sender, d.DeliveryDetails.Receiver, d.DeliveryDetails.FromCity, d.DeliveryDetails.ToCity)));
		}
	}
}
