using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Entities;

namespace UniformSystem.Data.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(64).IsRequired();

        builder.HasMany(p => p.Users).WithMany(u => u.Permissions);
        
        builder.HasIndex(p => p.Name).IsUnique();
    }
}