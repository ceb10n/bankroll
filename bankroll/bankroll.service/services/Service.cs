using bankroll.repository.repositories.interfaces;
using bankroll.service.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bankroll.service.services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
        }
        public virtual T FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public virtual IList<T> List()
        {
            return _repository.List().ToList();
        }

        public virtual void Add(T item)
        {
            _repository.Add(item);
        }

        public virtual void Remove(T item)
        {
            _repository.Remove(item);
        }

        public virtual void Edit(T item, Guid id)
        {
            _repository.Edit(item, id);
        }

    }
}
