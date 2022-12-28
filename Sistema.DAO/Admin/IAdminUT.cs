using Sistema.DAO.Core;

using System;

namespace Sistema.DAO.Admin
{
    public interface IAdminUT : IDisposable
    {
        RepositorioGenerico<Usuario> UsuarioRepository { get; }

        void Save();
    }
}
