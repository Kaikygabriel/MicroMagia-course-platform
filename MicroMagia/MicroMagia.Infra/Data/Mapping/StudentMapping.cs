using MicroMagia.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroMagia.Infra.Data.Mapping;

public class StudentMapping : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsPremium)
            .IsRequired(true);
        
        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .HasColumnType("NVARCHAR()")
            .IsRequired(true);
    }
}