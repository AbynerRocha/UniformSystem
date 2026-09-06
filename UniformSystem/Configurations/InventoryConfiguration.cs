using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Models;

namespace UniformSystem.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("tb_inventory");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(i => i.Uniform)
            .WithMany(u => u.Inventories)
            .HasForeignKey(i => i.UniformId);

        builder.HasOne(i => i.UpdatedBy)
            .WithMany(u => u.Inventories)
            .HasForeignKey(i => i.UpdatedById);

        builder.HasIndex(I => I.UniformId);
        builder.HasIndex(I => I.UpdatedById);
        builder.HasIndex(I => I.UpdatedAt);
    }
}