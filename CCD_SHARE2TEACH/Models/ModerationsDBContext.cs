using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{
    public class ModerationsDBContext : DbContext
    {
        public ModerationsDBContext(DbContextOptions<ModerationsDBContext> options) : base(options)
        {

        }
        public DbSet<MODERATIONS> MODERATIONS { get; set; } = null!;
    }
}
