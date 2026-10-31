using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniformSystem.Entities;

namespace UniformSystem.Data.Configurations;

public class TokenConfiguration : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.ToTable("tb_tokens");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Value).HasColumnName("token");
        builder.Property(p => p.IsRevoked).HasColumnName("token_revoked");
        builder.Property(p => p.Type).HasColumnName("token_type");

        builder.HasIndex(p => p.Value).IsUnique();
    }
}