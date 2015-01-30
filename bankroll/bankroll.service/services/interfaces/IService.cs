using System;
using System.Collections.Generic;

namespace bankroll.service.services.interfaces
{
    public interface IService<T> where T : class
    {
        T FindById(Guid id);
        IList<T> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item, Guid id);
    }
}
