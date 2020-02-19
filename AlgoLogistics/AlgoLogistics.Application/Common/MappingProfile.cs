using AlgoLogistics.Application.DTOs;
using AlgoLogistics.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Application.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<DeliveryDetailsDTO, DeliveryDetails>()
				.ConstructUsing(s => new DeliveryDetails(s.Sender, s.Receiver, s.FromCity, s.ToCity))
				.ReverseMap();

			CreateMap<PhysicalParametersDTO, PhysicalParameters>()
				.ConstructUsing(s => new PhysicalParameters(s.Width, s.Height, s.Length, s.Weight))
				.ReverseMap();
		}
	}
}
