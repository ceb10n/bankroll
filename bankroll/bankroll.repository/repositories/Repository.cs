using bankroll.domain.context;
using bankroll.repository.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.repository.repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BankrollContext _context;

        public Repository(BankrollContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        public T FindById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Edit(T item, Guid id)
        {
            if (item == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = _context.Entry<T>(item);

            if (entry.State == EntityState.Detached)
            {
                var set = _context.Set<T>();
                T attachedEntity = set.Find(id); 

                if (attachedEntity != null)
                {
                    var attachedEntry = _context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(item);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }

            _context.SaveChanges();
        }
    }
}
