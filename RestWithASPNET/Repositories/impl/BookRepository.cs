using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repositories.impl
{
    public class BookRepository : IBookRepository
    {
        private readonly SqlServerContext _context;

        public BookRepository(SqlServerContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            var books = _context.Books.Include(b => b.Author).ToList();
            return books;
        }

        public Book FindById(long id)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Where(b => b.Id.Equals(id))
                .FirstOrDefault();
            return book;
        }
    }
}
