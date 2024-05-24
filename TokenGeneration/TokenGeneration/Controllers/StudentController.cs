using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenGeneration.Contracts;
using TokenGeneration.Modals;
using TokenGeneration.Services;

namespace TokenGeneration.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentService;

        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }

        //[AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<StudentService>> Login(Student student)
        {
            var token = await _studentService.Login(student);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid login attempt.");
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> DemoMethod()
        {
            return Ok("Demo method success");
        }
    }
}
