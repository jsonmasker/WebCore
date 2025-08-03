using System.ComponentModel.DataAnnotations;

namespace Common.Custom.CustomDataAnnotations
{
    public class ConfirmPasswordValidation : ValidationAttribute
    {
        private readonly string _passwordPropertyName;

        public ConfirmPasswordValidation(string passwordPropertyName)
        {
            _passwordPropertyName = passwordPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the password property value from the validation context
            var passwordProperty = validationContext.ObjectType.GetProperty(_passwordPropertyName);

            if (passwordProperty == null)
            {
                return new ValidationResult("{Global.GetThiskyHallMessageValueByKey(EMessage.UnknownProperty, ELanguage.VN.ToString())}: {_passwordPropertyName}");
            }
            var password = passwordProperty.GetValue(validationContext.ObjectInstance, null) as string;
            string confirmPassword = value.ToString();
            //if the confirm password is empty
            if (string.IsNullOrEmpty(confirmPassword))
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.ConfirmPasswordDontAllowNull, ELanguage.VN.ToString())");
            }
            // Check if the confirm password is valid
            if (!string.Equals(password, confirmPassword))
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PasswodAndConfirmPasswordDontMatch, ELanguage.VN.ToString())");
            }

            return ValidationResult.Success;
        }
    }
}
