using RestPerson.Data.Converter.Implementation;
using RestPerson.Data.VO;
using RestPerson.Model;
using RestPerson.Repository;
using System;
using System.Collections.Generic;

namespace RestPerson.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter _converter;
        public BookBusinessImplementation(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }
        public BookVO Create(BookVO book)
        {
            Book bookEntity = _converter.Parse(book);
            return _converter.Parse(_bookRepository.Create(bookEntity));
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_bookRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_bookRepository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            Book bookEntity = _converter.Parse(book);
            return _converter.Parse(_bookRepository.Update(bookEntity));
        }
    }
}
