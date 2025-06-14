// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using SonXeber.Domain.Entities;

namespace SonXeber.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<News> News => Set<News>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Title).IsRequired().HasMaxLength(200);
            entity.Property(n => n.Content).IsRequired();
        });
    }
}
