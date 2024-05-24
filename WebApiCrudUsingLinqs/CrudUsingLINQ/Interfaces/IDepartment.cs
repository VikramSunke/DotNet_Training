using CrudUsingLINQ.Models;

namespace CrudUsingLINQ.Interfaces
{
    public interface IDepartment
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
        Task AddDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int id);
    }
} 
