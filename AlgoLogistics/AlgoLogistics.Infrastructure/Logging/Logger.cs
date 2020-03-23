using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Elasticsearch;
using System;

namespace AlgoLogistics.Infrastructure.Logging
{
	public static class Logger
	{
		public static ILogger Create()
		{
			return new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.LogToElasticSearch()
				.CreateLogger();
		}

		private static LoggerConfiguration LogToElasticSearch(this LoggerConfiguration loggerConfiguration)
		{
			return loggerConfiguration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(@"http://localhost:9200"))
			{
				AutoRegisterTemplate = true,
				AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
				IndexFormat = "algo-logistics-{0:yyyy.MM.dd}"
			});
		}
	}
}
