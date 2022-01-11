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
        private readonly BookResumeConverter _bookResumeConverter;
        private readonly IBookRepository _bookRepository;

        public BookBusinessImplementation(IRepository<Book> repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
            _converter = new BookConverter();
            _bookResumeConverter = new BookResumeConverter();
        }

        public BookVO Create(BookResumeVO book)
        {
            Book bookEntity = _bookResumeConverter.Parse(book);
            bookEntity = _bookRepository.Create(bookEntity);
            BookVO bookVo = _converter.Parse(bookEntity);
            return bookVo;
        }

        public BookVO Update(long id, BookResumeVO book)
        {
            var bookEntity = _bookResumeConverter.Parse(book);
            bookEntity = _bookRepository.Update(id, bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_bookRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            var book = _converter.Parse(_bookRepository.FindById(id));
            return book;
        }
    }
}
