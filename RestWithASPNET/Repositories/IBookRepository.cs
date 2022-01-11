using RestWithASPNET.Models;
using System.Collections.Generic;

namespace RestWithASPNET.Repositories
{
    public interface IBookRepository
    {
        List<Book> FindAll();
        
        Book FindById(long id);

        Book Update(long id, Book book);

        Book Create(Book book);
    }
}
