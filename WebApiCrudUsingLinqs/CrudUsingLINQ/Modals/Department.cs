using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingLINQ.Models
{
    public class Department
    {
        [Key] 
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Manager { get; set; }
    }
}
