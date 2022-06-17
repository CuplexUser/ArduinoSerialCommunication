using System;
using System.Globalization;
using System.IO;
using System.Text;
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
            var logLevel = LogEventLevel.Warning;
            string logFilePath = ApplicationBuildConfig.ApplicationLogFilePath();

            if (ApplicationBuildConfig.DebugMode)
            {
                logLevel = LogEventLevel.Verbose;
            }


            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Debug, standardErrorFromLevel: LogEventLevel.Error, formatProvider: CultureInfo.InvariantCulture)
                .WriteTo.File(path:logFilePath,restrictedToMinimumLevel: LogEventLevel.Information,retainedFileTimeLimit:TimeSpan.FromDays(30),
                    rollingInterval:RollingInterval.Day,rollOnFileSizeLimit:false,encoding:Encoding.UTF8)
                .Enrich.FromLogContext()
                .MinimumLevel.Is(logLevel)
                .CreateLogger();

            builder.RegisterLogger();
        }
    }
}
