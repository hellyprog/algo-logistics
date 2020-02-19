using AlgoLogistics.Application.Common;
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
			services.AddMediatR(Assembly.GetExecutingAssembly());

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			var mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			return services;
		}
	}
}
