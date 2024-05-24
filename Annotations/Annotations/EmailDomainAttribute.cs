using System;
using System.ComponentModel.DataAnnotations;

namespace Annotations
{
    public class EmailDomainAttribute : ValidationAttribute
    {
        private readonly string _domain;

        public EmailDomainAttribute(string domain)
        {
            _domain = domain.ToLower();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string email && email.Contains("@"))
            {
                var domain = email.Split('@')[1].ToLower();
                if (domain == _domain)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"Email domain must be {_domain}.");
            }
            return new ValidationResult("Invalid email format.");
        }
    }
}
