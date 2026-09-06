using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Models;
using UniformSystem.Repositories.Interfaces;

namespace UniformSystem.Repositories.Implementations;

public class EmployeeRepository(AppDatabaseContext dbContext) : IEmployeeRepository
{
    public async Task<Employee?> GetEmployeeAsync(int id)
    {
        return await dbContext.Employees.FindAsync(id);
    }

    public async Task<Employee?> GetEmployeeAsync(string email)
    {
        return await dbContext.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => string.Equals(e.Email, email, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await dbContext.Employees
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        await dbContext.Employees.AddAsync(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        dbContext.Employees.Update(employee);
    }

    public void DeleteEmployee(Employee employee)
    {
        dbContext.Employees.Remove(employee);
    }
}