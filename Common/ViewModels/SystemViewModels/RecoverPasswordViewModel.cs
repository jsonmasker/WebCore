using Common.Custom.CustomDataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class RecoverPasswordViewModel
    {
        [EmailValidation]
        [Required(ErrorMessage = "Email is required!")]
        public required string Email { get; set; }
    }
}
