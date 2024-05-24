using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenGeneration.Contracts;
using TokenGeneration.Data;
using TokenGeneration.Modals;

namespace TokenGeneration.Services
{
    public class StudentService : IStudent
    {
        private readonly IConfiguration _configuration;
        private readonly StudentDBContext _context;

        public StudentService(IConfiguration configuration, StudentDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<string> Login(Student student)
        {
            var studentRecord = await _context.Students.FirstOrDefaultAsync(s => s.UserName == student.UserName);
            if (studentRecord == null)
            {
                return string.Empty;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWTSECRET:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, student.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string userToken = tokenHandler.WriteToken(token);

                return userToken;
            }
        }
    }
}
