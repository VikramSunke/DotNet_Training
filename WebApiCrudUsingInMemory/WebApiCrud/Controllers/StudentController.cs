using Microsoft.AspNetCore.Mvc;
using WebApiCrud.Modals;
namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static int _lastId = 0;
        static List<StudentModal> studentsList = new List<StudentModal>();

        private List<StudentModal> StudentsList()
        {
            return studentsList;
        }

        [HttpGet("/GetStudentsList")]
        public IEnumerable<StudentModal> Get()
        {
            return StudentsList();
        }

        [HttpPost("/AddStudent")]
        public List<StudentModal> AddStudent(StudentModal studentDetails)
        {
            studentDetails.Id = ++_lastId;
            studentsList.Add(studentDetails);
            return StudentsList();
        }

        [HttpGet("/GetStudentById")]
        public ActionResult<StudentModal> GetStudentById(int id)
        {
            var student = studentsList.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound(); // Return HTTP 404 Not Found
            }
            return student;
        }

        [HttpPut("/UpdateStudentDetails")]
        public ActionResult<StudentModal> UpdateStudent(int id, StudentModal updatedStudentDetails)
        {
            var studentRecord = studentsList.FirstOrDefault(x => x.Id == id);
            if (studentRecord == null)
            {
                return NotFound(); // Return HTTP 404 Not Found if student not found
            }
            studentRecord.Name = updatedStudentDetails.Name;
            studentRecord.Age = updatedStudentDetails.Age;
            studentRecord.Branch = updatedStudentDetails.Branch;
            return studentRecord;
        }

        [HttpDelete("/DeleteStudentById")]
        public List<StudentModal> DeleteStudentById(int id)
        {
            var student = studentsList.FirstOrDefault(x => x.Id == id);
            studentsList.Remove(student);
            return StudentsList();
        }

    }
}
