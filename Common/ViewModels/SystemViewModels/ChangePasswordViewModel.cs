using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }
        [Required]
        public required string OldPassword { get; set; }
        [Required]
        public required string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public required string ConfirmPassword { get; set; }
    }
}
