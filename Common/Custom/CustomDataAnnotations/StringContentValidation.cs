using System.ComponentModel.DataAnnotations;

namespace Common.Custom.CustomDataAnnotations
{
    public class StringContentValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string content = value.ToString().Trim();
                //if the content is empty
                if (string.IsNullOrEmpty(content))
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.ContentDontAllowNull, ELanguage.VN.ToString())");
                }
                // Check if the content is valid
                if (content.Length < 1 || content.Length > 1000)
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.Length1To100, ELanguage.VN.ToString())");
                }
            }

            return ValidationResult.Success;
        }
    }
}
