using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)
{
    public DbSet<Course>Courses { get; set; }//Ok
    public DbSet<Career>Careers { get; set; }//Ok
    public DbSet<Student>Students { get; set; }//ok
    public DbSet<Author> Authors { get; set; } //ok
    public DbSet<User>Users { get; set; }//ok

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseMapping());
        modelBuilder.ApplyConfiguration(new CareerMapping());
        modelBuilder.ApplyConfiguration(new StudentMapping());
        modelBuilder.ApplyConfiguration(new AuthorMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
    }
}