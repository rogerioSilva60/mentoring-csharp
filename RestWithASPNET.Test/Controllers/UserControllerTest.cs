using Microsoft.AspNetCore.Mvc;
using Moq;
using RestWithASPNET.Business.Implementations;
using RestWithASPNET.Controllers;
using RestWithASPNET.Data.VO;
using System;
using Xunit;

namespace RestWithASPNET.Test.Controllers
{
    public class UserControllerTest
    {
        private MockRepository mockRepository;
        Mock<IUserBusiness> _mockUserBusiness;

        public UserControllerTest()
        {
            mockRepository = new MockRepository(MockBehavior.Default);
            _mockUserBusiness = mockRepository.Create<IUserBusiness>();
        }

        private UserController UserController()
        {
            return new UserController(_mockUserBusiness.Object);
        }

        [Fact]
        public void CreateUser()
        {
            //Arrange
            var user = new UserVO()
            {
                UserName= "Maria",
                Password= "123456"
            };

            var userController = UserController();
            _mockUserBusiness.Setup(x => x.Create(user)).Returns(true).Verifiable();

            //Action
            ActionResult<UserVO> response = userController.Create(user);
            OkResult result =(OkResult) response.Result;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void CreateErrorUser()
        {
            //Arrange
            UserVO user = null;

            var userController = UserController();

            //Action
            ActionResult<UserVO> response = userController.Create(user);
            BadRequestObjectResult result = (BadRequestObjectResult)response.Result;

            //Assert
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Invalid user request", result.Value);
        }

        [Fact]
        public void FailCreateUser()
        {
            //Arrange
            var user = new UserVO()
            {
                UserName = "Maria",
                Password = "123456"
            };

            var userController = UserController();

            //Action
            _mockUserBusiness.Setup(x => x.Create(user)).Returns(false).Verifiable();

            ActionResult<UserVO> response = userController.Create(user);
            BadRequestObjectResult result = (BadRequestObjectResult)response.Result;

            //Assert
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Failed to register the user", result.Value);
        }
    }
}
