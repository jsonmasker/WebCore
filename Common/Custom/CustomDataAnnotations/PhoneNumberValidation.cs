using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Common.Custom.CustomDataAnnotations
{
    public class PhoneNumberValidation : ValidationAttribute
    {
        public List<string> startPhoneNumber = new List<string>()
        {
            //Viettel
            "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039",
            //Vinaphone
            "088", "091", "094", "083", "084", "085", "081", "082",
            //Mobifone
            "089", "090", "093", "070", "079", "077", "076", "078",
            //Vietnamobile
            "092", "056", "058", "052", "059",
            //Gmobile
            "099", "059",
            //Itelecom
            "087"
        };
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString().Trim();
                //if the phone number is empty
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    return ValidationResult.Success;
                    //return new ValidationResult("PhoneNumber don't allow null");
                }

                // Check if the phone number is valid
                if (phoneNumber.Length < 10 || phoneNumber.Length > 11)
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PhoneNumberLimitedLength, ELanguage.VN.ToString())");
                }
                // Check if the start phone number is valid
                string startDigits = phoneNumber.Substring(0, 3); // Get the first three digits of the phone number
                if (!startPhoneNumber.Contains(startDigits))
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PhoneNumberMustBeMobileNoInVietNam, ELanguage.VN.ToString())");
                }

                //write regex to validate number
                Regex regex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");

                if (!regex.IsMatch(phoneNumber))
                {
                    return new ValidationResult("Global.GetThiskyHallMessageValueByKey(EMessage.PhoneNumberDontAllowSpecialCharacter, ELanguage.VN.ToString())");
                }
            }

            return ValidationResult.Success;
        }
    }
}
