using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Models;

namespace UniformSystem.Configurations;

public class UniformConfiguration : IEntityTypeConfiguration<Uniform>
{
    public void Configure(EntityTypeBuilder<Uniform> builder)
    {
        builder.ToTable("tb_uniform");
        
        builder.Property(e => e.Size).HasMaxLength(20);
        
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.Reference).IsUnique();
        builder.HasIndex(e => e.Sex);
        builder.HasIndex(e => e.UniformCategoryId);
    }
}