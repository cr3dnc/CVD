using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace CVD.IoC;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var dataAccess = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(dataAccess)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(dataAccess)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();
    }
}