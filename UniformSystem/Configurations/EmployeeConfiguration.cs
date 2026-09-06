using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Models;

namespace UniformSystem.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("tb_employees");
        
        builder.Property(e => e.Name).HasMaxLength(255);
        builder.Property(e => e.Email).HasMaxLength(255);
        
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Email).IsUnique();
    }
}