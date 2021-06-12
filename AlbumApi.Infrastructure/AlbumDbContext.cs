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
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public AlbumDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }
        public AlbumDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
