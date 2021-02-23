using Autofac;
using EntityFramework;

namespace Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(typeof(DataLayerModule).Assembly);
            // Automatic register if the class implement interface
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces().AsSelf();
        }
    }
}
