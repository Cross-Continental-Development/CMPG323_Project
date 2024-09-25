using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }
        public DbSet<USERS> USERS { get; set; } = null!;
    }
}
