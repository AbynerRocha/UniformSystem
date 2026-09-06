using UniformSystem.Models;

namespace UniformSystem.Repositories.Interfaces;

public interface IEmployeeRepository
{
    public Task<Employee?> GetEmployeeAsync(int id);
    public Task<Employee?> GetEmployeeAsync(string email);
    public Task<IEnumerable<Employee>> GetEmployeesAsync();
    
    public Task CreateEmployeeAsync(Employee employee);
    public void UpdateEmployee(Employee employee);
    public void DeleteEmployee(Employee employee);
}