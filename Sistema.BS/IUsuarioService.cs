using Sistema.DAO;

using System;
using System.Collections.Generic;

namespace Sistema.BS
{
    public interface IUsuarioService : IDisposable
    {
        IList<Usuario> Listar();

        Usuario BuscarPorId(int id);

        Usuario Insertar(Usuario usuario);

        IList<Usuario> InsertarVarios(IList<Usuario> usuario);

        Usuario BuscarPorNombre(string nombre);
    }
}
