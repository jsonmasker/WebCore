using Common.Custom.CustomDataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        //[Required]
        public string? FullName { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        [PasswordValidation]
        public required string Password { get; set; }
        [EmailValidation]
        public required string Email { get; set; }
        [PhoneNumberValidation]
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public List<int> RoleIdList { get; set; }
        public UserViewModel()
        {
            RoleIdList = new List<int>();
            CreatedOn = DateTime.Now;
            IsActive = true;
        }
    }
}
