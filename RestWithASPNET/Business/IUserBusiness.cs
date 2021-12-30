using RestWithASPNET.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business.Implementations
{
    public interface IUserBusiness
    {
        bool Create(UserVO user);
    }
}
