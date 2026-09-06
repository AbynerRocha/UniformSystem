using Microsoft.EntityFrameworkCore;
using UniformSystem.Models;

namespace UniformSystem.Data;

public class AppDatabaseContext(IConfiguration configuration, DbContextOptions options) : DbContext(options)
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") 
                                                ?? throw new NullReferenceException("Connection string is null");
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabaseContext).Assembly);
    }
    
    public DbSet<User> Users  => Set<User>();
    public DbSet<Uniform> Uniforms  => Set<Uniform>();
    public DbSet<Employee> Employees  => Set<Employee>();
    public DbSet<Inventory> Inventory  => Set<Inventory>();
    public DbSet<InventoryLogs> InventoryLogs  => Set<InventoryLogs>();
    public DbSet<UniformCategory> UniformCategories => Set<UniformCategory>();
    public DbSet<UniformDelivered>  UniformDelivered => Set<UniformDelivered>();
}