using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Common.Custom.CustomDataAnnotations
{
    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString().Trim();
                Regex regex = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$");
                if (!regex.IsMatch(email))
                {
                    return new ValidationResult("Email is invalid");

                }
            }
            return ValidationResult.Success;
        }
    }
}
