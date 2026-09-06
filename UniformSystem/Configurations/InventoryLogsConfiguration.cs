using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Models;

namespace UniformSystem.Configurations;

public class InventoryLogsConfiguration : IEntityTypeConfiguration<InventoryLogs>
{
    public void Configure(EntityTypeBuilder<InventoryLogs> builder)
    {
        builder.ToTable("tb_inventory_logs");
        
        builder.HasKey(i => i.Id);
        builder.Property(i => i.LogDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(l => l.Uniform)
            .WithMany(u => u.InventoryLogs)
            .HasForeignKey(l => l.UniformId);

        builder.HasOne(l => l.UpdatedBy)
            .WithMany(u => u.InventoryLogs)
            .HasForeignKey(l => l.UpdatedById);

        builder.HasIndex(l => l.UniformId);
        builder.HasIndex(l => l.UpdatedById);
        builder.HasIndex(l => l.LogDate);
    }
}