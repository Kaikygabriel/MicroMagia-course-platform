using MicroMagia.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroMagia.Infra.Data.Mapping;

public class CourseMapping : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Category).Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired(true);
        builder.Property(x=>x.Title)
            .HasMaxLength(120)
            .IsRequired(true);
        builder.Property(x=>x.Summary)
            .HasMaxLength(220)
            .IsRequired(true);
    }
}