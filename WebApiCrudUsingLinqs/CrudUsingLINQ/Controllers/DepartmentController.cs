using CrudUsingLINQ.Interfaces;
using CrudUsingLINQ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudUsingLINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;

        public DepartmentController(IDepartment departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments =await _departmentService.GetDepartments();
            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            await _departmentService.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartments), new { id = department.DeptId }, department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DeptId)
            {
                return BadRequest();
            }

            await _departmentService.UpdateDepartment(department);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department =await _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            await _departmentService.DeleteDepartment(id);

            return NoContent();
        }
    }
}
