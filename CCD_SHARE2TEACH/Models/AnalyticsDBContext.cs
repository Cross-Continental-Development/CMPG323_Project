using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{    
    public class AnalyticsDBContext : DbContext
    {
        public AnalyticsDBContext(DbContextOptions<AnalyticsDBContext> options) : base(options)
        {

        }
        public DbSet<ANALYTICS> ANALYTICS { get; set; } = null!;
    }
    
}
