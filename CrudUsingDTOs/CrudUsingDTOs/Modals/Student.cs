namespace CrudUsingDTOs.Modals
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public int Age { get; set; }
        public string College { get; set; }
        public string Gender { get; set; }
        public DateOnly JoiningDate { get; set; }
    }
}
