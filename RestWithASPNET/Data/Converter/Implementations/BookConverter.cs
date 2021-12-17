using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if(origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parse(List<BookVO> origins)
        {
            if (origins == null) return null;
            List<Book> books = origins.Select(item => Parse(item)).ToList();
            return books;
        }
        public List<BookVO> Parse(List<Book> origins)
        {
            if (origins == null) return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
