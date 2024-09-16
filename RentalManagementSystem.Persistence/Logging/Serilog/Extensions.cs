using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Exceptions;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Sinks.Elasticsearch;

namespace RentalManagementSystem.Persistence.Logging.Serilog
{
    public static class Extensions
    {
        public static void RegisterSerilog(this WebApplicationBuilder builder)
        {
            // Bind LoggerSettings from the appsettings.json
            builder.Services.Configure<LoggerSettings>(builder.Configuration.GetSection(nameof(LoggerSettings)));

            builder.Host.UseSerilog((context, services, serilogConfig) =>
            {
                // Retrieve LoggerSettings from DI
                var loggerSettings = services.GetRequiredService<IOptions<LoggerSettings>>().Value;

                // Configure enrichers and logging options based on LoggerSettings
                ConfigureEnrichers(serilogConfig, loggerSettings.AppName);
                ConfigureConsoleLogging(serilogConfig, loggerSettings.StructuredConsoleLogging);
                ConfigureFileLogging(serilogConfig, loggerSettings.WriteToFile);
                ConfigureElasticSearch(serilogConfig, loggerSettings.AppName, loggerSettings.ElasticSearchUrl, builder.Environment.EnvironmentName);
                SetLogLevelOverrides(serilogConfig);
                SetMinimumLogLevel(serilogConfig, loggerSettings.MinimumLogLevel);
            });
        }

        private static void ConfigureEnrichers(LoggerConfiguration serilogConfig, string appName) =>
            serilogConfig
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", appName)
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId();

        private static void ConfigureConsoleLogging(LoggerConfiguration serilogConfig, bool structuredConsoleLogging)
        {
            if (structuredConsoleLogging)
                serilogConfig.WriteTo.Console(new CompactJsonFormatter());
            else
                serilogConfig.WriteTo.Console();
        }

        private static void ConfigureFileLogging(LoggerConfiguration serilogConfig, bool writeToFile)
        {
            if (writeToFile)
                serilogConfig.WriteTo.File(
                    new CompactJsonFormatter(),
                    "Logs/logs.json",
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 5);
        }

        private static void ConfigureElasticSearch(LoggerConfiguration serilogConfig, string appName, string elasticSearchUrl, string environmentName)
        {
            if (!string.IsNullOrWhiteSpace(elasticSearchUrl))
            {
                try
                {
                    var formattedAppName = appName.ToLower().Replace(".", "-").Replace(" ", "-");
                    var indexFormat = $"{formattedAppName}-logs-{environmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}";

                    serilogConfig.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchUrl))
                    {
                        AutoRegisterTemplate = true,
                        IndexFormat = indexFormat,
                        MinimumLogEventLevel = LogEventLevel.Information,
                    }).Enrich.WithProperty("Environment", environmentName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error configuring ElasticSearch sink: {ex.Message}");
                }
            }
        }

        private static void SetLogLevelOverrides(LoggerConfiguration serilogConfig) =>
            serilogConfig
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Hangfire", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error);

        private static void SetMinimumLogLevel(LoggerConfiguration serilogConfig, string minLogLevel)
        {
            serilogConfig.MinimumLevel.Is(minLogLevel.ToLower() switch
            {
                "debug" => LogEventLevel.Debug,
                "information" => LogEventLevel.Information,
                "warning" => LogEventLevel.Warning,
                _ => LogEventLevel.Information,
            });
        }
    }
}
