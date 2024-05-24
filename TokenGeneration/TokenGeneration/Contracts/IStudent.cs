using Microsoft.AspNetCore.Mvc;
using TokenGeneration.Modals;

namespace TokenGeneration.Contracts
{
    public interface IStudent
    {
        public Task<string> Login(Student UserName);
        
    }
}
