using AlgoLogistics.Application.Common;
using AlgoLogistics.Application.Integration.Services;
using AlgoLogistics.Application.Interfaces;
using AlgoLogistics.Application.Services;
using AlgoLogistics.Domain.Interfaces;
using AlgoLogistics.Domain.Services;
using AlgoLogistics.Domain.Services.Implementation;
using AlgoLogistics.Infrastructure;
using AlgoLogistics.Infrastructure.Logging;
using AlgoLogistics.Middlewares;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace AlgoLogistics
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddHealthChecks();
			services.AddInfrastructure(Configuration);

			services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(Info).Assembly);
			services.AddSingleton(GetMapper());

			services.AddTransient<IPackageService, PackageService>();
			services.AddTransient<IShipmentService, ShipmentService>();
			services.AddTransient<ICityNetworkProvider, CityNetworkProvider>();
			services.AddTransient<IPriceCalculator, PriceCalculator>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "AlgoLogistics API", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHealthChecks("/health");
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseMiddleware<RequestResponseLoggingMiddleware>();
			app.UseMiddleware<ErrorHandlingMiddleware>();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlgoLogistics API v1");
			});
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
