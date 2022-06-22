using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using App.Turistando.Database.SqlServer;

namespace App.Turistando.Database.SqlServer.Repository
{
    public class EntityRepository<T> : IRepository<T>
        where T : class
    {
        public TuristandoSqlServerContext Context { get; private set; }

        protected DbSet<T> Set => Context.Set<T>();

        public EntityRepository(TuristandoSqlServerContext db_dbContext)
        {
            Context = db_dbContext;
        }

        public IQueryable<T> Query => Set;

        public T Find(params object[] keys)
        {
            return Set.Find(keys);
        }

        public IEnumerable<T> FindAll()
        {
            var teste = Set.AsNoTracking().ToList();
            return teste;
        }

        public void Adicionar(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Add(entity);
        }

        public void Salvar(T entity)
        {
            var props = typeof(T)
                .GetProperties()
                .Where(prop =>
                    Attribute.IsDefined(prop,
                        typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));

            var codeValue = (props.First().GetValue(entity).GetType().Name == "Int64" ? (long)props.First().GetValue(entity) : (int)props.First().GetValue(entity));

            if (codeValue == 0)
            {
                this.Adicionar(entity);
            }
            else
            {
                this.Atualizar(entity);
            }
        }

        public void Apagar(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Attach(entity);
            Set.Remove(entity);
        }


        public void Atualizar(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Attach(entity);
            entry.State = EntityState.Modified;
  
        }

        public void Update(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Attach(entity);
            entry.State = EntityState.Modified;

        }

        public T Selecionar(Expression<Func<T, bool>> predicate)
        {
            return Context
                    .Set<T>()
                    .AsNoTracking()
                    .SingleOrDefault(predicate);
        }

        public List<T> Listar(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query)
                    .AsNoTracking()
                    .ToList();
            }
            else
            {
                return query
                    .AsNoTracking()
                    .ToList();
            }
        }

        public bool Existe(Expression<Func<T, bool>> predicate)
        {
            return Context
                .Set<T>()
                .AsNoTracking()
                .Any(predicate);
        }

        public void DetachEntries()
        {
            foreach (var entry in this.Context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }


    }
}
