using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repositories.impl
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly SqlServerContext _context;

        public AuthorRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Author Create(Author author)
        {
            throw new NotImplementedException();
        }

        public List<Author> FindAll()
        {
            return _context.Authors.Include(a => a.Books).ToList();
        }

        public Author FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Author Update(long id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
