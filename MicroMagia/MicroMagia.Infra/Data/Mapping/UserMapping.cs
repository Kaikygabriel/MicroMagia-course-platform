using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.ObjectValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroMagia.Infra.Data.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Password)
            .HasMaxLength(160)
            .IsRequired(true);
        
        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Address)
                .HasColumnName("Email")
                .HasMaxLength(200)
                .IsRequired();
        });
    }
}