using Microsoft.EntityFrameworkCore;
namespace zadanie5.Models
{
    public sealed class AlbumContext : DbContext
    {        
        public DbSet<Album> Albums { get; set; }
        public DbSet<Singer> Singers { get; set; }

        public AlbumContext(DbContextOptions<AlbumContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}