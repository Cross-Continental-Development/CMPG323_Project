using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{
    public class GradeDbContext : DbContext
    {
        public GradeDbContext(DbContextOptions<GradeDbContext> options) : base(options)
        {

        }
        public DbSet<GRADE> GRADE { get; set; } = null!;
    }
}
