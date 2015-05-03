using System.Data.Entity;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.Repository.Contexts
{
    class ThankYouAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
