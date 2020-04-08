using AlgoLogistics.Infrastructure.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace AlgoLogistics
{
	public class Program
	{
		public static readonly string EnvName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

		public static void Main(string[] args)
		{
			Log.Logger = Logger.Create();

			try
			{
				Log.Information("Starting up");
				CreateHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Application start-up failed");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.SetBasePath(Directory.GetCurrentDirectory())
						  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
						  .AddJsonFile($"appsettings.{EnvName}.json", optional: true)
						  .AddEnvironmentVariables();
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>()
							  .UseSerilog();
				});
	}
}
