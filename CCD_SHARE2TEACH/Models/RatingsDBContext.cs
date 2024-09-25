using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{
    public class RatingsDbContext : DbContext
    {
        public RatingsDbContext(DbContextOptions<RatingsDbContext> options) : base(options)
        {

        }
        public DbSet<RATINGS> RATINGS { get; set; } = null!;
    }
}
