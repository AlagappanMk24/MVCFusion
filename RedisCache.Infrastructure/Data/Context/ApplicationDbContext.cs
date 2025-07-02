using Microsoft.EntityFrameworkCore;
using RedisCache.Domain.Entities;

namespace RedisCache.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CacheEntry> CacheEntries { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CacheEntry>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<CacheEntry>()
                .HasIndex(e => e.Key)
                .IsUnique();
        }
    }
}