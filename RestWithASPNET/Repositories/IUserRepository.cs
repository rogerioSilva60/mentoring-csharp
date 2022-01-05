using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System.Security.Cryptography;

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
