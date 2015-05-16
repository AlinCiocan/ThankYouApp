using System.Collections.Generic;
using System.Linq;
using ThankYouApp.Repository.DAOs;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.Tests.CustomFakes
{
    internal class FakeUserDao : IUserDao
    {
        private readonly List<User> _users = new List<User>();

        public bool AddUser(User newUser)
        {
            _users.Add(newUser);
            return true;
        }

        public User GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(user => user.Email == email);
        }
    }
}