using Autofac;

namespace EntityFramework
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
            builder.RegisterType<SchoolDBContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
