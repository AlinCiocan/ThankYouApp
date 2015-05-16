using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ThankYouApp.BusinessLogic.Services;
using ThankYouApp.Repository.DAOs;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.Tests.BusinessLogic
{
    [TestClass]
    public class UserServiceTest    
    {
        private const string SomeEmail = "email@domain.com";
        private const string SomePassword = "pa22word";

        private User _someUser;
        private Mock<IUserDao> _userDaoStub;
        private User _userWithWrongPassword;
           
        [TestInitialize]
        public void SetUp()
        {
            _someUser = new User { Email = SomeEmail, Password = SomePassword };
            _userWithWrongPassword = new User {Email = _someUser.Email, Password = "WrongPassword"};
            
            SetUpUserDaoStub();

        }

        private UserService CreateUserService(IUserDao userDao)
        {
            return new UserService(userDao);
        }

        // TODO: find a better name for this method
        private void SetUpUserDaoStub()
        {

            _userDaoStub = new Mock<IUserDao>();

            var users = new List<User>();

            _userDaoStub.Setup(userDao => userDao.GetUserByEmail(It.IsAny<string>()))
                .Returns((string email) => { return users.FirstOrDefault(user => user.Email == email); });
         
            _userDaoStub.Setup(userDao => userDao.AddUser(It.IsAny<User>()))
                        .Callback((User newUser) => users.Add(newUser))
                        .Returns(true);
        }

        [TestMethod]
        public void UserShouldBeAbleToLoginAfterRegistering()
        {
            var userService = CreateUserService(_userDaoStub.Object);

            userService.RegisterUser(_someUser);

            var result = userService.LoginUser(_someUser);
            Assert.IsTrue(result, "User could not login after registering.");
        }

        [TestMethod]
        public void UserShouldNotBeAbleToLoginWithAWrongPassword()
        {

            // Arrange
            var userService = CreateUserService(_userDaoStub.Object);
            
            // Act
            userService.RegisterUser(_someUser);
            var result = userService.LoginUser(_userWithWrongPassword);

            // Assert
            Assert.IsFalse(result, "User was able to login with a wrong password");
        }


        [TestMethod]
        public void UserShouldNotBeAbleToRegisterTwice()
        {
            // Arrange
            SetUpUserDaoStub();
            var userService = CreateUserService(_userDaoStub.Object);
            
            // Act
            bool hasFirstTimeRegistered = userService.RegisterUser(_someUser);
            bool hasSecondTimeRegistered = userService.RegisterUser(_someUser);
            
            // Assert
            Assert.IsTrue(hasFirstTimeRegistered);
            Assert.IsFalse(hasSecondTimeRegistered);
        }
    }

}