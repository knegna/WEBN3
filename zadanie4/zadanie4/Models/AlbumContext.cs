using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace zadanie4.Models
{
    public class AlbumContext : DbContext
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
