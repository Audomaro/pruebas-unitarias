using Ninject;

using Sistema.BS;
using Sistema.DAO.Admin;

using System.Reflection;

namespace Sistema.WebApiNinject.App_Start
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            StandardKernel kernel = new StandardKernel();

            // Resuleve el propio webapi/assembly
            kernel.Load(Assembly.GetExecutingAssembly());

            // Demas servicios
            kernel.Bind<IAdminUT>().To<AdminUT>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();

            return kernel;
        }
    }
}