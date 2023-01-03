using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;

using Sistema.BS;
using Sistema.DAO;
using Sistema.DAO.Admin;

using System.Reflection;

namespace Sistema.WebApiAutofac.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer CreateContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            // Resuleve el propio webapi
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Resuleve lo componentes pendientes; de preferencia resolver todos los componentes a usar.
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            // Autofac no resuelve el context db asi que se tiene que resolver manualmente
            builder.RegisterType<SistemaEntities>().As<SistemaEntities>();

            // Demas servicios
            builder.RegisterType<AdminUT>().As<IAdminUT>();
            builder.RegisterType<UsuarioService>().As<IUsuarioService>();

            // Genera el contenedor
            IContainer container = builder.Build();
            return container;
        }
    }
}