using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Implementations
{
    public class BookAuthorConverter : IParser<BookAuthorVO, Book>, IParser<Book, BookAuthorVO>
    {
        public Book Parse(BookAuthorVO origin)
        {
            return new Book
            {
                Id = origin.Id
            };
        }

        public BookAuthorVO Parse(Book origin)
        {
            return new BookAuthorVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<Book> Parse(List<BookAuthorVO> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<BookAuthorVO> Parse(List<Book> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
