using CrudUsingDTOs.Data;
using CrudUsingDTOs.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingDTOs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDbContext context;
        public StudentController(StudentDbContext studentDbContext)
        {
            context = studentDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await context.Students.ToListAsync();
            var studentDtos = new List<StudentDto>();

            foreach (var student in students)
            {
                var studentDto = new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Branch = student.Branch,
                    Age = student.Age,
                    Gender = student.Gender
                };
                studentDtos.Add(studentDto);
            }
            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Branch = student.Branch,
                Age = student.Age,
                Gender = student.Gender
            };

            return Ok(studentDto);
        }


        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Branch = studentDto.Branch,
                Age = studentDto.Age,
                Gender = studentDto.Gender,
                JoiningDate = DateOnly.FromDateTime(DateTime.Now),
                College = "NJC"
            };
            context.Students.Add(student);
            await context.SaveChangesAsync();

            studentDto.Id = student.Id;
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, studentDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id)
            {
                return BadRequest();
            }

            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            student.Name = studentDto.Name;
            student.Branch = studentDto.Branch;
            student.Age = studentDto.Age;
            student.Gender = studentDto.Gender;

            context.Entry(student).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            context.Students.Remove(student);

            await context.SaveChangesAsync();
            return NoContent();
        }
        private bool StudentExists(int id)
        {
            return context.Students.Any(e => e.Id == id);
        }
    }
}