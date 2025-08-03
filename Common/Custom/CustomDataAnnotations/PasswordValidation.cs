using System.ComponentModel.DataAnnotations;

namespace Common.Custom.CustomDataAnnotations
{
    public class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PasswordCannotNull, ELanguage.VN.ToString())");
            }

            string password = value.ToString();
            //if the password is empty
            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PasswordCannotNull, ELanguage.VN.ToString())");
            }
            // don't allow a pace in password
            if (password.Contains(" "))
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PasswordDontAllowSpace, ELanguage.VN.ToString())");
            }
            // Check if the password is valid
            if (password.Length < 6 || password.Length > 20)
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PasswordLimitLengthFrom6To20, ELanguage.VN.ToString())");
            }
            //Password requires at least one uppercase letter, one lowercase letter, one number and one special character
            //if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,20}$"))
            //{
            //    return new ValidationResult("Password must have at least one uppercase letter, one lowercase letter, one number and one special character");
            //}

            return ValidationResult.Success;
        }
    }
}
