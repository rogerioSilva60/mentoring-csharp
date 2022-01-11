using RestWithASPNET.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        List<BookVO> FindAll();
        BookVO FindById(long id);
        BookVO Create(BookResumeVO book);
        BookVO Update(long id, BookResumeVO book);
        void Delete(long id);
    }
}
