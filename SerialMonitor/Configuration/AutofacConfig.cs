using System.Reflection;
using Autofac;
using StorageModule.Configuration.AutofacModules;

namespace SerialMonitor.Configuration
{
    public static class AutofacConfig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            var thisAssembly = Assembly.GetExecutingAssembly();


            Assembly[] coreAssemblies = new Assembly[2];
            var storageModuleAssembly = GetStorageModuleAssembly();

            coreAssemblies[0] = thisAssembly;
            coreAssemblies[1] = storageModuleAssembly;

            if (storageModuleAssembly != null)
            {
                builder.RegisterAssemblyModules(storageModuleAssembly);
            }

            builder.RegisterAssemblyModules(thisAssembly);
            var container = builder.Build();


            return container;
        }


        private static Assembly GetStorageModuleAssembly()
        {
            // In => StorageModule.Configuration.AutofacModules.SerialMonitorModule
            return typeof(SerialMonitorModule).Assembly;
        }
    }
}