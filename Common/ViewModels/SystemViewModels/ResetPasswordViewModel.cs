using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Token { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required!")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match!")]
        public required string ConfirmPassword { get; set; }
    }
}
