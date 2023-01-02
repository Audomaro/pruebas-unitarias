using Ninject.Modules;

using Sistema.BS;
using Sistema.DAO.Admin;

namespace Sistema.ConsolaNinject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            // Unidad de tranajo
            Bind<IAdminUT>().To<AdminUT>();

            // Servicio de usuario
            Bind<IUsuarioService>().To<UsuarioService>();

            // Este registro pertenece a la clase que servira como arranque, esto se hace para
            // No instanciar la clase; 'new StartUp' en program.cs y sacarle proyecto a Ninject
            Bind<StartUp>().To<StartUp>();
        }
    }
}
