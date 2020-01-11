using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_4
{
    public class AlbumStoreContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Singer> Singers { get; set; }

        public AlbumStoreContext(DbContextOptions<AlbumStoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=AlbumstoreNew63;Username=postgres;Password= ;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
