using System.Security.Cryptography;
using System.Threading.Tasks;
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

        public bool RegisterUser(User newUser)
        {
            if (IsUserAlreadyInDatabase(newUser))
            {
                return false;
            }

            return _userDao.AddUser(newUser);
        }

        private bool IsUserAlreadyInDatabase(User newUser)
        {
            return _userDao.GetUserByEmail(newUser.Email) != null;
        }

        public bool LoginUser(User user)
        {
            var userFromDb = _userDao.GetUserByEmail(user.Email);
            if (userFromDb == null)
            {
                return false;
            }

            return userFromDb.Password == user.Password;
        }
    }
}
