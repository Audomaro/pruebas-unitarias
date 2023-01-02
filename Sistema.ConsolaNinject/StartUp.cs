using Sistema.BS;

using System;

namespace Sistema.ConsolaNinject
{
    internal class StartUp
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
