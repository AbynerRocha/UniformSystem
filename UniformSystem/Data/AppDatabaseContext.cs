using Microsoft.EntityFrameworkCore;
using UniformSystem.Entities;
using UniformSystem.Features.Permissions;

namespace UniformSystem.Data;

public class AppDatabaseContext(IConfiguration configuration, DbContextOptions options) : DbContext(options)
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")
                                                ?? throw new NullReferenceException("Connection string is null");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_connectionString)
            .UseSnakeCaseNamingConvention()
            .UseSeeding((context, _) => PermissionSeeder.Seed(context))
            .UseAsyncSeeding((context, _, cancellationToken) =>
                PermissionSeeder.SeedAsync(context, cancellationToken));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabaseContext).Assembly);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Token> Tokens => Set<Token>();
    public DbSet<Uniform> Uniforms => Set<Uniform>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Inventory> Inventory => Set<Inventory>();
    public DbSet<InventoryLogs> InventoryLogs => Set<InventoryLogs>();
    public DbSet<UniformCategory> UniformCategories => Set<UniformCategory>();
    public DbSet<UniformDelivered> UniformDelivered => Set<UniformDelivered>();
}
