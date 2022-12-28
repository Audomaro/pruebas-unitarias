using System.Data.Common;

namespace Sistema.DAO
{
    public partial class SistemaEntities
    {
        public SistemaEntities(DbConnection connection) : base(connection, true)
        {
        }
    }
}