using Domain;
using Domain.Quiz;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Quiz> Sections  { get; set; }
    public DbSet<Quiz> Questions  { get; set; }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Quiz>()
            .HasMany(q => q.Sections)
            .WithOne()
            .HasForeignKey(s => s.QuizId);

        builder.Entity<Section>()
            .HasMany(s => s.Questions)
            .WithOne(q => q.Section)
            .HasForeignKey(q => q.SectionId);
    }
}
