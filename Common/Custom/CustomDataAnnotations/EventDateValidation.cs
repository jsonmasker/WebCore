//using Common.ViewModels.ThiskyhallViewModels;
//using System.ComponentModel.DataAnnotations;


//namespace Common.CustomDataAnnotations
//{
//    public class EventDateValidation : ValidationAttribute
//    {
//        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//        {
//            var model = (EventViewModel)validationContext.ObjectInstance;

//            if (model.EventStartDate > model.EventEndDate)
//                return new ValidationResult(Global.GetThiskyHallMessageValueByKey(EMessage.EventStartDateCannotLaterEventEndDate, ELanguage.VN.ToString()));

//            if (model.RegistrationStartDate > model.RegistrationEndDate)
//                return new ValidationResult(Global.GetThiskyHallMessageValueByKey(EMessage.RegistrationStartDateCannotLaterRegistrationEndDate, ELanguage.VN.ToString()));

//            if (model.RegistrationEndDate > model.EventStartDate)
//                return new ValidationResult(Global.GetThiskyHallMessageValueByKey(EMessage.RegistrationEndDateCannotLaterEventStartDate, ELanguage.VN.ToString()));

//            return ValidationResult.Success;
//        }
//    }
//}
