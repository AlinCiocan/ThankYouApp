using ThankYouApp.Repository.DAOs;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.BusinessLogic.Services
{
    public class UserService
    {

        private readonly IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void RegisterUser(User newUser)
        {
            _userDao.AddUser(newUser);
        }

        public bool LoginUser(User user)
        {
            return true;
        }
    }
}
