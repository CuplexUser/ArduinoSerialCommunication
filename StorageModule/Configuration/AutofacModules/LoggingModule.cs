using System;
using System.Globalization;
using System.IO;
using Autofac;
using AutofacSerilogIntegration;
using Serilog;
using Serilog.Events;

namespace StorageModule.Configuration.AutofacModules
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var logLevel = LogEventLevel.Debug;
            string logFilePath;
            if (!ApplicationBuildConfig.DebugMode)
            {
                logLevel = LogEventLevel.Warning;
                logFilePath = ApplicationBuildConfig.ApplicationLogFilePath();
            }
            else
            {
                logFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"SerialMonitor{DateTime.Today.ToString("yyyy-MM-dd")}.log");
            }

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Debug, standardErrorFromLevel: LogEventLevel.Error, formatProvider: CultureInfo.InvariantCulture)
                .WriteTo.File(logFilePath,
                    fileSizeLimitBytes: 1048576,
                    retainedFileCountLimit: 31,
                    restrictedToMinimumLevel: logLevel,
                    buffered: false,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff} [{Level}] {Message}{NewLine}{Exception}{Data}")
                .Enrich.FromLogContext()
                .MinimumLevel.Is(logLevel)
                .CreateLogger();

            builder.RegisterLogger();
        }
    }
}
