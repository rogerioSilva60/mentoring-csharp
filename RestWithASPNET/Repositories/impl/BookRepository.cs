using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;
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

        public Book Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return FindById(book.Id);
        }

        public Book Update(long id, Book book)
        {
            var result = _context.Books
                .Include(a => a.Author)
                .SingleOrDefault(p => p.Id.Equals(id));
            book.Id = id;
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }
    }
}
