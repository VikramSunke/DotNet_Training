namespace CrudUsingLINQ.Models
{
    public class EmployeeWithDepartmentDto
    {
        public int Id { get; set; }
        public string Ename { get; set; }
        public int EAge { get; set; }
        public decimal ESalary { get; set; }
        public string EPosition { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Manager { get; set; }
    }
}
