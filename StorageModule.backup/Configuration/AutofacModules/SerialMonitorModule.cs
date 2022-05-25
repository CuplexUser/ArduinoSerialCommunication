using System.Collections.Generic;
using System.Configuration.Provider;
using System.Reflection;
using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using StorageModule.Repositories;
using StorageModule.Services;
using Module = Autofac.Module;

namespace StorageModule.Configuration.AutofacModules
{

    public class SerialMonitorModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServiceBase).Assembly)
                .AssignableTo<ServiceBase>()
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(RepositoryBase).Assembly)
                .AssignableTo<RepositoryBase>()
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

            //builder.RegisterAssemblyTypes(typeof(ProviderBase).Assembly)
            //    .AssignableTo<ProviderBase>()
            //    .AsSelf()
            //    .AsImplementedInterfaces()
            //    .SingleInstance();

            builder.Register(context => context.Resolve<MapperConfiguration>()
                    .CreateMapper())
                .As<IMapper>()
                .AutoActivate()
                .SingleInstance();

            builder.Register(Configure)
                .AutoActivate()
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

            var assembly = ApplicationBuildConfig.SerialMonitorAssembly;

            builder.RegisterAutoMapper(assembly);
            builder.RegisterAssemblyTypes(assembly)
                .AssignableTo<System.Windows.Forms.Form>()
                .AsSelf()
                .InstancePerDependency();
        }

        private static MapperConfiguration Configure(IComponentContext context)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                var innerContext = context.Resolve<IComponentContext>();
                cfg.ConstructServicesUsing(innerContext.Resolve);

                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            });

            return configuration;
        }
    }
}
