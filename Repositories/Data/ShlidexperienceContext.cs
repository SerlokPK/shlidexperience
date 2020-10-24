using Microsoft.EntityFrameworkCore;

namespace Repositories.Data
{
    public class ShlidexperienceContext : DbContext
    {
        public ShlidexperienceContext(DbContextOptions<ShlidexperienceContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
