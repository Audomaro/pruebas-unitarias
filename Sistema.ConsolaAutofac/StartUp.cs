using Sistema.BS;

using System;

namespace Sistema.ConsolaAutofac
{
    internal class StartUp : IStartUp
    {
        private readonly IUsuarioService _usuarioSvc;

        public StartUp(IUsuarioService usuarioSvc)
        {
            _usuarioSvc = usuarioSvc;
        }

        public void Run()
        {
            Console.WriteLine($"Total {_usuarioSvc.Listar().Count}");
        }
    }
}
