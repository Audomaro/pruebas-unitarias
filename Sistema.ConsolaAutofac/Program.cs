using Autofac;
using Autofac.Features.ResolveAnything;

using Sistema.BS;
using Sistema.DAO;
using Sistema.DAO.Admin;

namespace Sistema.ConsolaAutofac
{
    internal class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            Container = Register();

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IStartUp usuarioService = scope.Resolve<IStartUp>();
                usuarioService.Run();
            }

        }

        private static IContainer Register()
        {
            ContainerBuilder builder = new ContainerBuilder();

            // Resuleve lo componentes pendientes; de preferencia resolver todos los componentes a usar.
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            // Autofac no resuelve el context db asi que se tiene que resolver manualmente
            builder.RegisterType<SistemaEntities>().As<SistemaEntities>();

            // Demas servicios
            builder.RegisterType<AdminUT>().As<IAdminUT>();
            builder.RegisterType<UsuarioService>().As<IUsuarioService>();
            builder.RegisterType<StartUp>().As<IStartUp>();

            return builder.Build();
        }
    }
}
