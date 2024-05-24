using CrudUsingLINQ.Data;
using CrudUsingLINQ.Interfaces;
using CrudUsingLINQ.Modals;
using CrudUsingLINQ.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CrudUsingLINQ.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly EmployeeDBContext _context;

        public EmployeeService(EmployeeDBContext context)
        {
            _context = context;
        }


        public async Task AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
             _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee); 
                await _context.SaveChangesAsync();
            }
        }




        //Simple Data
        public async Task<List<Employee>> GetEmployees()
        {
            return await (from e in _context.Employees select e).ToListAsync();
        }



        //Simple Data with Where
        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees
                                         .Where(e => e.Id == id)
                                         .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<List<Employee>> GetEmployeeWithPosition(string position)
        {
            return await (from e in _context.Employees
                    where e.EPosition == position
                    select e).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesWithAge(int age)
        {
            return await (from e in _context.Employees
                    where e.EAge >= age
                    select e).ToListAsync();
        }
       




        // Aggregate functions
        public async Task<int> GetEmployeeCount()
        {
            return await (from e in _context.Employees
                    select e).CountAsync();
        }
        public async Task<double> GetAverageSalary()
        {
            return await(from e in _context.Employees
                    select Convert.ToDouble(e.ESalary)).AverageAsync();
        }
        public async Task<decimal> GetMaxSalary()
        {
            return await _context.Employees.MaxAsync(e => e.ESalary);
        }
        public async Task<decimal> GetMinSalary()
        {
            return await (from e in _context.Employees
                    select e.ESalary).MinAsync();
        }
        public async Task<decimal> GetTotalSalary()
        {
            return await _context.Employees.SumAsync(e => e.ESalary);
        }






        //Joins
        public async Task<List<EmployeeWithDepartmentDto>> GetEmployeesWithDepartment()
        {
            var query = from e in _context.Employees
                        join d in _context.Departments on e.DeptId equals d.DeptId
                        select new EmployeeWithDepartmentDto
                        {
                            Id = e.Id,
                            Ename = e.Ename,
                            EAge = e.EAge,
                            ESalary = e.ESalary,
                            EPosition = e.EPosition,
                            DeptId = e.DeptId,
                            DeptName = d.DeptName,
                            Manager = d.Manager
                        };
            /* var query = _context.Employees
                    .Join(_context.Departments,
                          e => e.DeptId,
                          d => d.DeptId,
                          (e, d) => new EmployeeWithDepartmentDto
                          {
                              Id = e.Id,
                              Ename = e.Ename,
                              EAge = e.EAge,
                              ESalary = e.ESalary,
                              EPosition = e.EPosition,
                              DeptId = e.DeptId,
                              DeptName = d.DeptName,
                              Manager = d.Manager
                          });*/
            return await query.ToListAsync();
        }

        //Joins with order by
        public async Task<List<EmployeeWithDepartmentDto>> GetEmployeesOrderByDeptName()
        {
            var query = _context.Employees.Join(_context.Departments,
                                                e => e.DeptId, d => d.DeptId,
                                                (e, d) => new { Employee = e, Department = d })
                                                .OrderBy(ed => ed.Department.DeptName)
                                                .Select(ed => new EmployeeWithDepartmentDto
                                                {
                                                    Id = ed.Employee.Id,
                                                    Ename = ed.Employee.Ename,
                                                    EAge = ed.Employee.EAge,
                                                    ESalary = ed.Employee.ESalary,
                                                    EPosition = ed.Employee.EPosition,
                                                    DeptId = ed.Employee.DeptId,
                                                    DeptName = ed.Department.DeptName,
                                                    Manager = ed.Department.Manager
                                                });
            return await query.ToListAsync();
        }






        //Order By
        public async Task<List<Employee>> GetEmployeesOrderByName()
        {
            var query = from e in _context.Employees
                        orderby e.Ename
                        select e;
            return await query.ToListAsync();
        }





        //groupBy
        public async Task<List<DepartmentWithEmployeeCountDto>> GetEmployeeCountByDepartment()
        {
            var query = (from e in _context.Employees
                         join d in _context.Departments
                         on e.DeptId equals d.DeptId
                         group e by d.DeptName into g
                         select new DepartmentWithEmployeeCountDto
                         {
                             DeptName = g.Key,
                             EmployeeCount = g.Count()
                         });
            return await query.ToListAsync();
        }

    }
}
