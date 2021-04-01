using System.Globalization;
using System.Reflection;
using Serilog;
using Serilog.Events;

namespace StorageModule.Configuration
{

        public class SerilogConfig : Module
        {
            //protected override void Load(ContainerBuilder builder)
            //{

            //    Log.Logger = new LoggerConfiguration()
            //                 .WriteTo.RollingFile(ApplicationBuildConfig.ApplicationLogFilePath(true),
            //                     fileSizeLimitBytes: 1048576,
            //                     retainedFileCountLimit: 31,
            //                     restrictedToMinimumLevel: logLevel,
            //                     buffered: false,
            //                     outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff} [{Level}] {Message}{NewLine}{Exception}{Data}")
            //                 .Enrich.FromLogContext()
            //                 .MinimumLevel.Is(logLevel)
            //                 .CreateLogger();

            //    builder.RegisterLogger();
            //}
        }
   
}