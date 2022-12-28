using Sistema.DAO.Core;

using System;

namespace Sistema.DAO.Admin
{
    public class AdminUT : IAdminUT
    {
        private bool _disposed = false;
        private SistemaEntities _context;

        public AdminUT(SistemaEntities context)
        {
            _context = context;
        }

        public RepositorioGenerico<Usuario> UsuarioRepository => new RepositorioGenerico<Usuario>(_context);


        public void Save()
        {
            _context.SaveChanges();
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
                _context.Dispose();
                _context = null;
            }

            _disposed = true;
        }
    }
}
