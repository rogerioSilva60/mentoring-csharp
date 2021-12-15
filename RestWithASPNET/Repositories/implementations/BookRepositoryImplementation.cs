using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repositories.implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private SqlServerContext _context;

        public BookRepositoryImplementation(SqlServerContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            } catch(Exception)
            {
                throw;
            }
            return book;
        }

        public void Delete(long id)
        {
            var oldBook = _context.Books.SingleOrDefault(b => b.Id.Equals(id));
            if(oldBook != null)
            {
                try
                {
                    _context.Books.Remove(oldBook);
                    _context.SaveChanges();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(b => b.Id.Equals(id));
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (Exists(book.Id))
            {
                var oldBook = _context.Books.SingleOrDefault(b => b.Id.Equals(book.Id));
                if (oldBook != null)
                {
                    try
                    {
                        _context.Entry(oldBook).CurrentValues.SetValues(book);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return book;
                }

            }

            return null;
        }
    }
}
