using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ThankYouApp.BusinessLogic;
using ThankYouApp.BusinessLogic.Services;
using ThankYouApp.Repository;
using ThankYouApp.Repository.DAOs;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.Tests.BusinessLogic
{
    [TestClass]
    public class UserServiceTest    
    {   
        //TODO: Think about a way that will describe the register - login process in tests

        [TestMethod]
        [Ignore]
        public void UserShouldBeAbleToRegisterIfHisEmailAddressIsUnique()
        {
            var userDao = new Mock<IUserDao>();
            var userService = new UserService(userDao.Object);


            var user = new User();


            userService.RegisterUser(user);
        }

        [TestMethod]
        [Ignore]
        public void UserShouldNotBeAbleToRegisterTwice()
        {
            var userDao = new Mock<IUserDao>();
            var userService = new UserService(userDao.Object);


            var user = new User();


            userService.RegisterUser(user);
            userService.RegisterUser(user);
        }

    }
}
