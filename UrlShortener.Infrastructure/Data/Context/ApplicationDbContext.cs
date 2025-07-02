using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ShortUrl> ShortUrls { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortUrl>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<ShortUrl>()
                .HasIndex(s => s.ShortCode)
                .IsUnique();
        }
    }
}
