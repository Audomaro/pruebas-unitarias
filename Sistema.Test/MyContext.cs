using Sistema.DAO;

using System.Data.Common;
using System.Data.Entity;

namespace Sistema.Test
{
    internal class MyContext : DbContext
    {
        public MyContext(DbConnection connection) : base(connection, true)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
