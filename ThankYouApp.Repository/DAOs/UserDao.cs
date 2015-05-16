using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using ThankYouApp.Repository.Contexts;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.Repository.DAOs
{
    public class UserDao : IUserDao
    {
        private ThankYouAppContext GetRepository()
        {
              return new ThankYouAppContext();  
        }

        public bool AddUser(User newUser)
        {
            var repository = GetRepository(); 
            using (repository)
            {
                repository.Users.Add(newUser);
                int numberOfRowsInsertedInDb = repository.SaveChanges();
                return numberOfRowsInsertedInDb > 0;
            }
        }

        public User GetUserByEmail(string email)
        {
            var repository = GetRepository(); 
            using (repository)
            {
                return repository.Users.FirstOrDefault(user => user.Email == email);                
            }
        }
    }
}
