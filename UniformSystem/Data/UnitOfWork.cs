using Microsoft.EntityFrameworkCore;

namespace UniformSystem.Data;

public sealed class UnitOfWork(AppDatabaseContext dbContext) : IUnitOfWork
{
    public async Task ExecuteTransactionAsync(Func<Task> func)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            await func();
            await transaction.CommitAsync();
        }
        catch 
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}