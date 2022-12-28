using Sistema.DAO;
using Sistema.DAO.Admin;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.BS
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IAdminUT _adminUoW;
        private bool _disposed;

        public UsuarioService(IAdminUT adminUoW)
        {
            _adminUoW = adminUoW;
        }

        public IList<Usuario> Listar()
        {
            return _adminUoW.UsuarioRepository.Listar();
        }

        public Usuario BuscarPorId(int id)
        {
            return _adminUoW.UsuarioRepository.BuscarPorId(id);
        }
        public Usuario BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException("nombre", "No se proporciono el nombre");
            }

            return _adminUoW.UsuarioRepository.BuscarPorCondiciones(c => c.Nombre == nombre);
        }

        public Usuario Insertar(Usuario usuario)
        {
            if (usuario is null)
            {
                throw new ArgumentNullException("usuario", "Nio hay datos de usuario");
            }

            Usuario existe = _adminUoW.UsuarioRepository.BuscarPorCondiciones(c => c.Nombre == usuario.Nombre);

            if (existe != null)
            {
                throw new UsuarioException("El usuario ya existe");
            }

            _adminUoW.UsuarioRepository.Insertar(usuario);
            _adminUoW.Save();

            return usuario;
        }

        public IList<Usuario> InsertarVarios(IList<Usuario> usuarios)
        {
            if (!usuarios?.Any() ?? true)
            {
                throw new ArgumentNullException("usuarios", "Lista vacia");
            }

            _adminUoW.UsuarioRepository.InsertarVarios(usuarios);
            _adminUoW.Save();

            return usuarios;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _adminUoW.Dispose();
            }

            _disposed = true;
        }
    }
}
