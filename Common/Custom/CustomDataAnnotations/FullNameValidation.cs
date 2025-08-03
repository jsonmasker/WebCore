using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Common.Custom.CustomDataAnnotations
{
    public class FullNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fullName = value.ToString().Trim();
            //if the full name is empty
            if (string.IsNullOrEmpty(fullName))
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.FullnameDontAllowNull, ELanguage.VN.ToString())");
            }
            // Check if the full name is valid
            if (fullName.Length < 3 || fullName.Length > 50)
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.FullNameHaveLimitedLength, ELanguage.VN.ToString())");
            }
            string regex = @"^[\p{L}\p{M}\s]+$";
            if (!Regex.IsMatch(fullName, regex))
            {
                return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.FullNameDontAllowSpecialCharacter, ELanguage.VN.ToString())");
            }

            return ValidationResult.Success;
        }
    }
}
