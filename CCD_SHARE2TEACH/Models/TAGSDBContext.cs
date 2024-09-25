using CCD_SHARE2TEACH.Models;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{    
    public class TAGSDbContext : DbContext
    {
        public TAGSDbContext(DbContextOptions<TAGSDbContext> options) : base(options)
        {

        }
        public DbSet<TAGS> TAGS { get; set; } = null!;
    }

    
}
