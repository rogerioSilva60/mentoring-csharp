using Moq;
using RestWithASPNET.Business.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using RestWithASPNET.Repositories;
using RestWithASPNET.Repositories.Generic;
using System;
using System.Security.Cryptography;
using Xunit;

namespace RestWithASPNET.Test.Business
{
    public class UserBusinessTest
    {
        Mock<IUserRepository> _mockUserRepository;
        Mock<IRepository<User>> _mockGenericRepository;

        public UserBusinessTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockGenericRepository = new Mock<IRepository<User>>();
        }

        private UserBusinessImplementation UserBusiness(
            Mock<IUserRepository> mockUserRepository, Mock<IRepository<User>> mockGenericRepository)
        {
            return new UserBusinessImplementation(
                mockGenericRepository.Object, mockUserRepository.Object);
        }

        [Fact]
        public void CreateUser()
        {
            //Arrange
            var userVO = new UserVO()
            {
                UserName = "Maria",
                Password = "123456"
            };

            string pass = "654321";
            var savedUser = new User
            {
                Id = 1,
                UserName = userVO.UserName,
                Password = pass,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7)
            };

            _mockGenericRepository.Setup(x => x.Create(It.IsAny<User>())).Returns(savedUser);
            _mockUserRepository.Setup(c => c.ComputeHash(
                userVO.Password, It.IsAny<SHA256CryptoServiceProvider>())).Returns(pass);

            //Action
            var userBusiness = UserBusiness(_mockUserRepository, _mockGenericRepository);
            bool response = userBusiness.Create(userVO);

            //Assert
            Assert.True(response);
        }
    }
}
