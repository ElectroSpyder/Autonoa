using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.ILogica.IGenericRepository;

namespace Autonoa.Solucion.ILogica
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AutonoaEntities AutonoaContext { get; set; } 

        public int Add(T entity)
        {
            AutonoaContext.Set<T>().Add(entity);
            return Save();
        }

        public int Delete(T entity)
        {
            AutonoaContext.Set<T>().Remove(entity);
            return Save();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicado)
        {
            return AutonoaContext.Set<T>().Where(predicado).ToList();
        }

        public T FindOneBy(Expression<Func<T, bool>> predicado)
        {
            return AutonoaContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public int Edit(T entity)
        {
            AutonoaContext.Set<T>().AddOrUpdate(entity);
            return Save();
        }

        public int Save()
        {
           return AutonoaContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return AutonoaContext.Set<T>().ToList();
        }

        #region IDisposable Support

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposedValue) return;
            if (disposing)
            {
                AutonoaContext.Dispose();
            }
            this._disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion


    }
}