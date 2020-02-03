using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_api.Models
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
    }
}
