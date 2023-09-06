using System.ComponentModel.DataAnnotations;

namespace E_COMMERCEMVC.Models
{
    public class UniqueEmailAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string Email = value.ToString();
            Context context = new Context();
            Customer customer = context.Customers. FirstOrDefault(e => e.Email== Email);
            if (customer == null)
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Email Already Found");
        }
    }
}
