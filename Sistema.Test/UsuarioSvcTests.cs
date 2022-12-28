using Sistema.BS;
using Sistema.DAO;
using Sistema.DAO.Admin;

using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

using Xunit;

using Z.EntityFramework.Extensions;

namespace Sistema.Test
{
    public class UsuarioSvcTests
    {
        #region Practicas y detalles encontrados
        [Fact]
        public void ConDbContextOriginal()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            EntityFrameworkManager.ContextFactory = context => new SistemaEntities(connection);

            using (var context = new SistemaEntities(connection))
            {
                context.Usuario.AddRange(DatosEjemplo());
                context.SaveChanges();

                Assert.True(context.Usuario.Any());
            }
        }

        [Fact]
        public void ConMiDbContext()
        {
            // Arrange
            //DbConnection connection = Effort.DbConnectionFactory.CreateTransient();

            //using (var context = new MyContext(connection))
            //{
            //    context.Usuario.AddRange(GetUsuario());
            //    context.SaveChanges();

            //    var list = context.Usuario.ToList();

            //    Assert.True(list.Count == 2);
            //}

            //Effort.Provider.EffortConnection conn = Effort.DbConnectionFactory.CreateTransient();
            //SistemaEntities s = new SistemaEntities(conn);

            //s.Usuario.AddRange(GetUsuario());

            //var conteo = s.Usuario.ToList();

            //Assert.True(conteo.Any());


            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            EntityFrameworkManager.ContextFactory = context => new MyContext(connection);

            using (var context = new MyContext(connection))
            {
                context.Usuario.AddRange(DatosEjemplo());
                context.SaveChanges();

                Assert.True(context.Usuario.Any());
            }
        }
        #endregion

        [Fact]
        public void CuandoNoExistenUsuarios()
        {
            IUsuarioService usuarioSvc = new UsuarioService(new AdminUT(FakeDB()));

            IList<Usuario> usuarios = usuarioSvc.Listar();

            Assert.False(usuarios.Any());
        }

        [Fact]
        public void CuandoExistenUsuarios()
        {
            IUsuarioService usuarioSvc = CrearSvc();

            usuarioSvc.Insertar(new Usuario() { Nombre = "Usuario" });

            IList<Usuario> usuarios = usuarioSvc.Listar();

            Assert.True(usuarios.Any());
        }

        [Fact]
        public void CuandoSeInserta()
        {
            IUsuarioService usuarioSvc = CrearSvc();

            Usuario usuarioNuevo = usuarioSvc.Insertar(new Usuario() { Nombre = "Joe" });

            Assert.Equal(1, usuarioNuevo.UsuarioId);
        }

        [Fact]
        public void CuandoSeInsertanVarios()
        {
            IUsuarioService usuarioSvc = CrearSvc();

            IList<Usuario> usuariosNuevos = usuarioSvc.InsertarVarios(DatosEjemplo());
            IList<Usuario> usuariosExistentes = usuarioSvc.Listar();

            Assert.Equal(usuariosExistentes.Count(), usuariosNuevos.Count());
        }

        [Fact]
        public void CuandoNoExisteSrX()
        {
            IUsuarioService usuarioSvc = CrearSvc();

            Usuario existe = usuarioSvc.BuscarPorNombre("Sr. X");

            Assert.True(existe is null);
        }

        [Fact]
        public void CuandoYaExisteSrX()
        {
            IUsuarioService usuarioSvc = CrearSvc();

            usuarioSvc.Insertar(new Usuario { Nombre = "Sr. X" });

            Assert.Throws<UsuarioException>(() => usuarioSvc.Insertar(new Usuario { Nombre = "Sr. S" }));
        }

        private IList<Usuario> DatosEjemplo()
        {
            return new List<Usuario>() {
                                new Usuario()
                                {
                                    Nombre = "Audomaro"
                                },
                                new Usuario()
                                {
                                    Nombre = "Joe"
                                }
            };

        }

        private static UsuarioService CrearSvc()
        {
            return new UsuarioService(new AdminUT(FakeDB()));
        }

        private static SistemaEntities FakeDB()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            EntityFrameworkManager.ContextFactory = context => new SistemaEntities(connection);
            return new SistemaEntities(connection);
        }
    }
}