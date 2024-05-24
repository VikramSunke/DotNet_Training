namespace Annotations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string code)
            {
                if (IsEmployeeCodeValid(code))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Employee code must be 5 characters long, start with 'Q', and be followed by 4 digits.");
            }
            return new ValidationResult("Invalid employee code format.");
        }

        private bool IsEmployeeCodeValid(string code)
        {
            if (code.Length != 5)
            {
                return false;
            }

            if (code[0] != 'Q')
            {
                return false;
            }

            if (!int.TryParse(code.Substring(1), out int number))
            {
                return false;
            }

            return true;
        }
    }

}
