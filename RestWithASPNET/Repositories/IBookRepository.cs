using RestWithASPNET.Models;
using System.Collections.Generic;

namespace RestWithASPNET.Repositories
{
    public interface IBookRepository
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        bool Exists(long id);
    }
}
