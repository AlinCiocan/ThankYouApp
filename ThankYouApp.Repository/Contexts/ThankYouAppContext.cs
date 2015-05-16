using System.Data.Entity;
using ThankYouApp.Repository.Models;

namespace ThankYouApp.Repository.Contexts
{
    public class ThankYouAppContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
