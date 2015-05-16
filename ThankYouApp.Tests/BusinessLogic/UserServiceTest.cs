using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThankYouApp.BusinessLogic.Services;
using ThankYouApp.Repository.DAOs;
using ThankYouApp.Repository.Models;
using ThankYouApp.Tests.CustomFakes;

namespace ThankYouApp.Tests.BusinessLogic
{
    [TestClass]
    public class UserServiceTest    
    {
        private const string SomeEmail = "email@domain.com";
        private const string SomePassword = "pa22word";

        private User _someUser;
        private User _userWithWrongPassword;

        private IUserDao _userDaoStub;

        [TestInitialize]
        public void SetUp()
        {
            _someUser = new User { Email = SomeEmail, Password = SomePassword };
            _userWithWrongPassword = new User {Email = _someUser.Email, Password = "WrongPassword"};
            
            _userDaoStub = new FakeUserDao();
        }

        private UserService CreateUserService()
        {
            return new UserService(_userDaoStub);
        }

        [TestMethod]
        public void UserShouldBeAbleToLoginAfterRegistering()
        {
            var userService = CreateUserService();

            userService.RegisterUser(_someUser);
            var result = userService.LoginUser(_someUser);
            
            Assert.IsTrue(result, "User could not login after registering.");
        }

        [TestMethod]
        public void UserShouldNotBeAbleToLoginWithAWrongPassword()
        {
            var userService = CreateUserService();
            
            userService.RegisterUser(_someUser);
            var result = userService.LoginUser(_userWithWrongPassword);

            Assert.IsFalse(result, "User was able to login with a wrong password");
        }


        [TestMethod]
        public void UserShouldNotBeAbleToRegisterTwice()
        {
            var userService = CreateUserService();
            
            bool hasFirstTimeRegistered = userService.RegisterUser(_someUser);
            bool hasSecondTimeRegistered = userService.RegisterUser(_someUser);
            
            Assert.IsTrue(hasFirstTimeRegistered);
            Assert.IsFalse(hasSecondTimeRegistered);
        }
    }

}