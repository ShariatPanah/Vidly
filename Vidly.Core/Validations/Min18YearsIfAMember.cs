using System.ComponentModel.DataAnnotations;
using Vidly.Core.Domain;

namespace Vidly.Core.Validations
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown 
                    || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = (DateTime.Now - customer.Birthdate).Value.TotalDays / 365;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("The User should be at least 18 years old to go on a membership.");
        }
    }
}
