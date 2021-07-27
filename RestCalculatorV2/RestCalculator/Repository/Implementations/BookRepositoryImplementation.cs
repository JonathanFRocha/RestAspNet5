using RestPerson.Model;
using RestPerson.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPerson.Repository.Implementations
{
    public class BookRepositoryImplementation:IBookRepository
    {
        private MySQLContext _dbContext;

        public BookRepositoryImplementation(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Book Create(Book book)
        {
            try
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            Book foundBook = _dbContext.Books.SingleOrDefault(book => book.Id == id);
            if(foundBook != null)
            {
                try
                {
                    _dbContext.Books.Remove(foundBook);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Book> FindAll()
        {
            return _dbContext.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _dbContext.Books.SingleOrDefault(book => book.Id == id);
        }

        public Book Update(Book book)
        {
            if (Exists(book.Id)) return null;
            Book foundBook = _dbContext.Books.SingleOrDefault(b => b.Id == book.Id);
            if(foundBook != null)
            {
                try
                {
                    _dbContext.Entry(foundBook).CurrentValues.SetValues(book);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        public bool Exists(long id)
        {
            return _dbContext.Persons.Any(p => p.Id == id);
        }
    }
}
