using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Sistema.DAO.Core
{
    public class RepositorioGenerico<TEntity> where TEntity : class
    {
        internal DbContext Contexto;
        internal DbSet<TEntity> DbSet;

        public RepositorioGenerico(DbContext context)
        {
            Contexto = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IList<TEntity> Listar()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        public virtual TEntity BuscarPorId(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insertar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void InsertarVarios(IList<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Eliminar(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);

            if (entityToDelete != null)
            {
                Eliminar(entityToDelete);
            }
        }

        public virtual void Modificar(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Contexto.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual TEntity BuscarPorCondiciones(Expression<Func<TEntity, bool>> predicado)
        {
            return DbSet.FirstOrDefault(predicado);
        }
    }
}
