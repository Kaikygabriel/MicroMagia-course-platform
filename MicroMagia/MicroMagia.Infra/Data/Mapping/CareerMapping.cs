using MicroMagia.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroMagia.Infra.Data.Mapping;

public class CareerMapping : IEntityTypeConfiguration<Career>
{
    public void Configure(EntityTypeBuilder<Career> builder)
    {
        builder.ToTable("Careers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .HasMaxLength(140)
            .IsRequired(true);
        builder.HasMany(x => x.Courses);
    }
}