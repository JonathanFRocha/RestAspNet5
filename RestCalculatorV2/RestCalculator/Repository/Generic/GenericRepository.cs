using Microsoft.EntityFrameworkCore;
using RestPerson.Model.Base;
using RestPerson.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestPerson.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _dbContext;
        private DbSet<T> _dataset;
        public GenericRepository(MySQLContext context)
        {
            _dbContext = context;
            _dataset = _dbContext.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _dbContext.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            T FoundItem = _dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (FoundItem != null)
            {
                try
                {
                    _dataset.Remove(FoundItem);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id == id);
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;
            T foundItem = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (foundItem != null)
            {
                try
                {
                    _dbContext.Entry(foundItem).CurrentValues.SetValues(item);
                    _dbContext.SaveChanges();
                    return item;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }


        }

        public bool Exists(long id)
        {
            return _dataset.Any(p => p.Id == id);
        }
    }
}
