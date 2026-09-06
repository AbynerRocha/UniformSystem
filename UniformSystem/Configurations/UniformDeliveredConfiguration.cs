using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Models;

namespace UniformSystem.Configurations;

public class UniformDeliveredConfiguration : IEntityTypeConfiguration<UniformDelivered>
{
    public void Configure(EntityTypeBuilder<UniformDelivered> builder)
    {
        builder.ToTable("tb_uniforms_delivered");
        
        builder.HasKey(I => I.Id);
        
        builder.Property(I => I.DeliveredAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.HasOne(I => I.ToEmployee)
            .WithMany(e => e.UniformDelivered)
            .HasForeignKey(I => I.ToEmployeeId);
        
        builder.HasOne(I => I.DeliveredBy)
            .WithMany(d => d.UniformDelivered)
            .HasForeignKey(I => I.DeliveredById);
        
        builder.HasOne(I => I.Uniform)
            .WithMany(u => u.UniformDelivered)
            .HasForeignKey(I => I.UniformId);
        
        builder.HasIndex(I => I.UniformId);
        builder.HasIndex(I => I.ToEmployeeId);
        builder.HasIndex(I => I.DeliveredById);
        builder.HasIndex(I => I.DeliveredAt);
    }
}