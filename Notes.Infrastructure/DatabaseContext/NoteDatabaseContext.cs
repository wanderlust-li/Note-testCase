using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;

namespace Notes.Infrastructure.DatabaseContext;

public class NoteDatabaseContext : DbContext
{
    public NoteDatabaseContext(DbContextOptions<NoteDatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Note> Notes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoteDatabaseContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}