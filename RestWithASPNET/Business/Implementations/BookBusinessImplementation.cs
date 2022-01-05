using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using RestWithASPNET.Repositories;
using RestWithASPNET.Repositories.Generic;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        private readonly IBookRepository _bookRepository;

        public BookBusinessImplementation(IRepository<Book> repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _converter = new BookConverter();
            _bookRepository = bookRepository;
        }

        public BookVO Create(BookVO book)
        {
            Book bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            BookVO bookVo = _converter.Parse(bookEntity);
            return bookVo;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            //_converter.Parse(_repository.FindAll());
            return _converter.Parse(_bookRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            var book = _converter.Parse(_bookRepository.FindById(id));
            return book;
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
    }
}
