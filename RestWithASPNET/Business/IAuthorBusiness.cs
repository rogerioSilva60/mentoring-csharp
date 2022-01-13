using RestWithASPNET.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business
{
    public interface IAuthorBusiness
    {
        List<AuthorVO> FindAll();
    }
}
