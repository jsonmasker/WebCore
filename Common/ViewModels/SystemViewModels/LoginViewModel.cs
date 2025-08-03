using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class LoginViewModel
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
