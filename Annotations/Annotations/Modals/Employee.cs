using System.ComponentModel.DataAnnotations;

namespace Annotations.Modals
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [EmailDomain("qualminds.com", ErrorMessage = "Email must be from the qualminds.com domain.")]
        public string Email { get; set; }

        [Compare("vikram123")]
        public string Password { get; set; }

        [MaxLength(50)]
        public string EmployeeAddress { get; set; }

        [MinLength(10)]
        public string EmployeeShortAddress { get; set; }


        [EmployeeCode(ErrorMessage = "Employee code must be 5 characters long, start with 'Q', and be followed by 4 digits.")]
        public string EmployeeCode { get; set; }
    }
}
