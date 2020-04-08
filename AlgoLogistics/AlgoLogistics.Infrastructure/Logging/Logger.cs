using Serilog;
using Serilog.Formatting.Elasticsearch;
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
			return loggerConfiguration
				.WriteTo.Logger(lc => lc.Filter
					.ByIncludingOnly(l => l.Properties.ContainsKey(LoggingConstants.TypeKey))
					.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(@"http://localhost:9200"))
					{
						AutoRegisterTemplate = true,
						AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
						CustomFormatter = new ElasticsearchJsonFormatter(),
						IndexFormat = "algo-logistics-{0:yyyy.MM.dd}"
					}));
		}

		public static void LogException(Exception e)
		{
			Log.Logger
				.ForContext(LoggingConstants.TypeKey, LoggingConstants.ExceptionLogType)
				.Error("Error: {error_message}\nStack trace: {stack_trace}",
					e.Message,
					e.StackTrace);
		}
	}
}
