namespace UniformSystem.Data;

public interface IUnitOfWork
{
    Task ExecuteTransactionAsync(Func<Task> func);
}