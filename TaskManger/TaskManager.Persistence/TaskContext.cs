using Microsoft.EntityFrameworkCore;

namespace TaskManager.Persistence;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>()
            .HasIndex(s => s.Id)
            .IsUnique();
        modelBuilder.Entity<TaskEntity>()
            .Property(s => s.AssignedTo)
            .IsRequired()
            .HasMaxLength(30);
        modelBuilder.Entity<TaskEntity>()
            .Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<TaskEntity>()
            .Property(s => s.Description)
            .IsRequired()
            .HasMaxLength(1000);
        modelBuilder.Entity<TaskEntity>()
            .Property(s => s.Status)
            .IsRequired();
        modelBuilder.Entity<TaskEntity>()
            .Property(s => s.AssignedTo)
            .HasMaxLength(30)
            .IsRequired(false);
        modelBuilder.Entity<TaskEntity>()
            .Property(s => s.CreatedTime)
            .IsRequired();
        modelBuilder.Entity<TaskEntity>()
            .Property(s => s.Index)
            .IsRequired(false);
    }
}
