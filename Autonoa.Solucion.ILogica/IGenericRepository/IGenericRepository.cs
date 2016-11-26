using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Autonoa.Solucion.ILogica.IGenericRepository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicado);
        T FindOneBy(Expression<Func<T, bool>> predicado);
        int Add(T entity);
        int Delete(T entity);
        int Edit(T entity);
        int Save();
    }
}
