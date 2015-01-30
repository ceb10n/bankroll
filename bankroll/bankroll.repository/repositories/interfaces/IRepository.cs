using System;
using System.Linq;

namespace bankroll.repository.repositories.interfaces
{
    public interface IRepository<T> where T : class
    {
        T FindById(Guid id);
        IQueryable<T> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item, Guid id);
    }
}
