using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using App.Turistando.Database.SqlServer;

namespace App.Turistando.Database.SqlServer.Repository
{
    public interface IRepository<T> where T : class
    {
        void Salvar(T entity);
        void Update(T entity);
        void Apagar(T entity);

        //So you do this
        T Find(params object[] keys);

        public List<T> Listar(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        public T Selecionar(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindAll();

        //Might as well add this as well.
        IQueryable<T> Query { get; }

        TuristandoSqlServerContext Context { get; }

        bool Existe(Expression<Func<T, bool>> predicate);

        void DetachEntries();
    }
}
