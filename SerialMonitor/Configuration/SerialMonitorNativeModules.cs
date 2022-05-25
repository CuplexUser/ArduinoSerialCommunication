using Autofac;
using JetBrains.Annotations;
using SerialMonitor.Service;

namespace SerialMonitor.Configuration
{
    /// <inheritdoc />
    [UsedImplicitly]
    public class SerialMonitorNativeModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServiceBase).Assembly)
                .AssignableTo<ServiceBase>()
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}