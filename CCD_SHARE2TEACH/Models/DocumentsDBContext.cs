using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{
    public class DocumentsDbContext : DbContext
    {
        public DocumentsDbContext(DbContextOptions<DocumentsDbContext> options) : base(options)
        {

        }
        public DbSet<DOCUMENTS> DOCUMENTS { get; set; } = null!;
    }
}
