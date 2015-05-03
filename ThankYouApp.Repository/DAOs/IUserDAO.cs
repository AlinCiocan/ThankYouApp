using ThankYouApp.Repository.Models;

namespace ThankYouApp.Repository.DAOs
{
    public interface IUserDao
    {
        void AddUser(User newUser);
    }
}
