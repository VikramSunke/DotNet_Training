using CrudUsingAsyncAwait.Data;
using CrudUsingAsyncAwait.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingAsyncAwait.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDbContext context;
        public StudentController(StudentDbContext _context)
        {
            context = _context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            // Retrieve all students asynchronously.
            return await context.Students.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            // Check if the requested student exists.
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound(); // Return 404 if not found.
            }
            return student; // Return the student if found.
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();

            // Return a response with the new student's data and URL for retrieval.
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> PutStudentRecord(int id, Student student)
        {
            // Ensure the provided ID matches the student's ID.
            if (id != student.Id)
            {
                return BadRequest(); // Return 400 Bad Request.
            }
            // Update the student asynchronously.
            context.Entry(student).State = EntityState.Modified;
            await context.SaveChangesAsync();

            // Return a response with no content.
            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            // Check if the requested student exists.
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound(); // Return 404 if not found.
            }

            // Remove the student asynchronously.
            context.Students.Remove(student);
            await context.SaveChangesAsync();

            // Return a response with no content.
            return NoContent();
        }
    }
}
