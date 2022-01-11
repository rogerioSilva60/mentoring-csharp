using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Implementations
{
    public class BookResumeConverter : IParser<BookResumeVO, Book>, IParser<Book, BookResumeVO>
    {
        public Book Parse(BookResumeVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Title= origin.Title,
                LaunchDate= origin.LaunchDate,
                Price= origin.Price,
                AuthorId = origin.Author == null ? null : origin.Author.Id
            };
        }

        public BookResumeVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookResumeVO
            {
                Title = origin.Title,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Author = origin.AuthorId == null ? null : new BaseIdVO{ Id= origin.AuthorId}
            };
        }

        public List<Book> Parse(List<BookResumeVO> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<BookResumeVO> Parse(List<Book> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
