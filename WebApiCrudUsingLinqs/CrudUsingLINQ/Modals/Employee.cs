using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingLINQ.Models
{
    public class Employee
    {
        [Key] 
        public int Id { get; set; }
        public string Ename { get; set; }
        public int EAge { get; set; }
        public decimal ESalary { get; set; }
        public string EPosition { get; set; }

        [ForeignKey("Department")] 
        public int DeptId { get; set; }
    }
}
