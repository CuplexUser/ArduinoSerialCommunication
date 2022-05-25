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
            var storageModuleAssembly = GetStorageModuleAssembly();

            Assembly[] coreAssemblies = new Assembly[2];
            coreAssemblies[0] = thisAssembly;
            coreAssemblies[1] = storageModuleAssembly;

            foreach (Assembly assembly in coreAssemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }

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