using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> FindAll();

        Author FindById(long id);

        Author Update(long id, Author author);

        Author Create(Author author);
    }
}
