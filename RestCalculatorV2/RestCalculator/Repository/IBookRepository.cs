using RestPerson.Model;
using System.Collections.Generic;

namespace RestPerson.Repository
{
    public interface IBookRepository
    {
        public Book Create(Book book);
        public List<Book> FindAll();
        public Book FindById(long id);
        public Book Update(Book book);
        public void Delete(long id);
    }
}
