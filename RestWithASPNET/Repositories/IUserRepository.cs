using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RestWithASPNET.Repositories
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string userName);

        bool RevokeToken(string userName);

        User RefreshUserInfo(User user);

        string ComputeHash(string password, SHA256CryptoServiceProvider algorithm);
    }
}
