using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{
    public class FAQDBContext : DbContext
    {
        public FAQDBContext(DbContextOptions<FAQDBContext> options) : base(options)
        {

        }
        public DbSet<FAQ> FAQ { get; set; } = null!;
    }
}
