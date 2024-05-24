using CrudUsingLINQ.Interfaces;
using CrudUsingLINQ.Modals;
using CrudUsingLINQ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudUsingLINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeService.UpdateEmployee(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id); 
            if (employee == null)
            {
                return NotFound();
            }
            await _employeeService.DeleteEmployee(id); 
            return NoContent();
        }






        //Simple Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees);
        }




        //Simple Data with Where

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet("position/{position}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesWithPosition(string position)
        {
            var employees = await _employeeService.GetEmployeeWithPosition(position);
            return Ok(employees);
        }

        [HttpGet("age/{age}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesWithAge(int age)
        {
            var employees =await _employeeService.GetEmployeesWithAge(age);
            return Ok(employees);
        }






        // Aggregate functions
        
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetEmployeeCount()
        {
            var count = await _employeeService.GetEmployeeCount();
            return Ok(count);
        }

        [HttpGet("average-salary")]
        public async Task<ActionResult<decimal>> GetAverageSalary()
        {
            var averageSalary =await _employeeService.GetAverageSalary();
            return Ok(averageSalary);
        }

        [HttpGet("max-salary")]
        public async Task<ActionResult<decimal>> GetMaxSalary()
        {
            var maxSalary =await _employeeService.GetMaxSalary();
            return Ok(maxSalary);
        }

        [HttpGet("min-salary")]
        public async Task<ActionResult<decimal>> GetMinSalary()
        {
            var minSalary =await _employeeService.GetMinSalary();
            return Ok(minSalary);
        }

        [HttpGet("total-salary")]
        public async Task<ActionResult<decimal>> GetTotalSalary()
        {
            var totalSalary =await _employeeService.GetTotalSalary();
            return Ok(totalSalary);
        }





        // Joins
        [HttpGet("EmployeesWithDepartment")]
        public async Task<ActionResult<IEnumerable<EmployeeWithDepartmentDto>>> GetEmployeesWithDepartment()
        {
            var employees = await _employeeService.GetEmployeesWithDepartment();
                return Ok(employees);
        }

        [HttpGet("GetEmployeesOrderByDeptName")]
        public async Task<ActionResult<IEnumerable<EmployeeWithDepartmentDto>>> GetEmployeesOrderByDeptName()
        {
            var employees = await _employeeService.GetEmployeesOrderByDeptName();
            return Ok(employees);
        }




        //Order by
        [HttpGet("GetEmployeeOrderByName")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesOrderByName()
        {
            var employees = await _employeeService.GetEmployeesOrderByName();
            return Ok(employees);
        }




        //Group By
        [HttpGet("EmployeeCountGroupByDepartment")]
        public async Task<ActionResult<IEnumerable<DepartmentWithEmployeeCountDto>>> GetEmployeeCountByDepartment()
        {
            var employees =await _employeeService.GetEmployeeCountByDepartment();
            return Ok(employees);
        }
    }
}
