using System.Threading.Tasks;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.Repository.DAOs
{
    public interface IUserDao
    {
        bool AddUser(User newUser);
        User GetUserByEmail(string email);
    }
}
