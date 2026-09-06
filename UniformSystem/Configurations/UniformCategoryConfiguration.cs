using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Models;

namespace UniformSystem.Configurations;

public class UniformCategoryConfiguration : IEntityTypeConfiguration<UniformCategory>
{
    public void Configure(EntityTypeBuilder<UniformCategory> builder)
    {
        builder.ToTable("tb_uniform_category");
        builder.Property(c => c.Name).HasMaxLength(255);
    }
}