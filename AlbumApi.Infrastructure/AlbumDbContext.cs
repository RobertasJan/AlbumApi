using AlbumApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AlbumApi.Infrastructure
{
    public class AlbumDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public AlbumDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
