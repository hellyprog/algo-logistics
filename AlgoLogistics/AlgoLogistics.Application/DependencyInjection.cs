using AlgoLogistics.Application.Common;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AlgoLogistics.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddTransient<IShipmentService, ShipmentService>();

			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddSingleton(GetMapper());

			return services;
		}

		private static IMapper GetMapper()
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			return mappingConfig.CreateMapper();
		}
	}
}
