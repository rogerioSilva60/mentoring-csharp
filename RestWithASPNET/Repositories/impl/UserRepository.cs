using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNET.Repositories.impl
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _context;

        public UserRepository(SqlServerContext context)
        {
            _context = context;
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null; ;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch(Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName.Equals(userName));
        }

        public bool RevokeToken(string userName)
        {
            var result = _context.Users.SingleOrDefault(u => u.UserName.Equals(userName));
            if (result == null) return false;
            
            User user = result;
            user.RefreshToken = null;
            user.Password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            _context.Entry(result).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return true;
        }

        public string ComputeHash(string password, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User Create(User t)
        {
            throw new NotImplementedException();
        }

        public User FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public User Update(User t)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }
    }
}
