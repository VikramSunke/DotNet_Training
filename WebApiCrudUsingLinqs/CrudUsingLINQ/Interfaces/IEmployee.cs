using CrudUsingLINQ.Modals;
using CrudUsingLINQ.Models;
using System.Collections.Generic;

namespace CrudUsingLINQ.Interfaces
{
    public interface IEmployee
    {
        
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);



        // Simple Data
        Task<List<Employee>> GetEmployees();



        //Simple Data with Where
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> GetEmployeeWithPosition(string position);
        Task<List<Employee>> GetEmployeesWithAge(int age);



        //Aggregate Functions
        Task<int> GetEmployeeCount();
        Task<double> GetAverageSalary();
        Task<decimal> GetMaxSalary();
        Task<decimal> GetMinSalary();
        Task<decimal> GetTotalSalary();



        //Joins
        Task<List<EmployeeWithDepartmentDto>> GetEmployeesWithDepartment();
        Task<List<EmployeeWithDepartmentDto>> GetEmployeesOrderByDeptName();



        //Order By
        Task<List<Employee>> GetEmployeesOrderByName();



        //Group By
        Task<List<DepartmentWithEmployeeCountDto>> GetEmployeeCountByDepartment();

    }
}
