using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Common.Custom.CustomDataAnnotations
{
    public class IDCardValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string idCard = value.ToString().Trim();
                //if the ID card is empty
                if (string.IsNullOrEmpty(idCard))
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.CardIDDontAllowNull, ELanguage.VN.ToString())");
                }
                // Check if the ID card is valid
                if (idCard.Length < 9 || idCard.Length > 20)
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.CardIDLimitedLength, ELanguage.VN.ToString())");
                }
                //write regex to validate number and character
                Regex regex = new Regex(@"^[a-zA-Z0-9]+$");

                if (!regex.IsMatch(idCard))
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.CardIDDontAllowSpecialCharacter, ELanguage.VN.ToString())");
                }
            }

            return ValidationResult.Success;
        }
    }
}
